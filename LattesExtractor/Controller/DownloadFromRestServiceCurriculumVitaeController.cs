using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using LattesExtractor.Collections;
using LattesExtractor.Entities;
using LattesExtractor.Entities.Database;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading;

namespace LattesExtractor.Controller
{
    class DownloadFromRestServiceCurriculumVitaeController
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(DownloadFromRestServiceCurriculumVitaeController).Name);

        private LattesModule _lattesModule;
        private Channel<CurriculoEntry> _curriculumVitaesForDownload;
        private Channel<CurriculoEntry> _curriculumVitaesForProcess;

        private string _urlMetadata = "http://buscacv.cnpq.br/buscacv/rest/espelhocurriculo/{0}";
        private string _urlDownloadXml = "http://buscacv.cnpq.br/buscacv/rest/download/curriculo/{0}";

        public DownloadFromRestServiceCurriculumVitaeController(
            LattesModule lattesModule,
            LattesDatabase db,
            Channel<CurriculoEntry> curriculumVitaesForDownload,
            Channel<CurriculoEntry> curriculumVitaesForProcess
        )
        {
            _lattesModule = lattesModule;
            _curriculumVitaesForDownload = curriculumVitaesForDownload;
            _curriculumVitaesForProcess = curriculumVitaesForProcess;
        }

        public void DownloadUpdatedCurriculums(ManualResetEvent doneEvent)
        {
            try
            {
                foreach (var curriculumVitae in _curriculumVitaesForDownload.Range())
                {
                    DownloadCurriculumVitae(curriculumVitae);
                }
            }
            finally
            {
                doneEvent.Set();
                Logger.Info(String.Format("Download terminou"));
            }
        }

        private void DownloadCurriculumVitae(CurriculoEntry curriculumVitae)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    var stream = wc.OpenRead(String.Format(_urlMetadata, curriculumVitae.NumeroCurriculo));

                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(MetadataResponse));
                    var response = ser.ReadObject(stream) as MetadataResponse;

                    if (response.CodRhCript == null || response.CodRhCript.Trim().Length == 0)
                    {
                        Logger.Error(String.Format(
                            "Não foi possível baixar o currículo de número {0}",
                            curriculumVitae.NumeroCurriculo
                        ));
                        _lattesModule.DecrementProcessCount();
                        return;
                    }

                    curriculumVitae.NomeProfessor = response.Document.NomeCompleto;

                    if (NeedsToBeUpdated(curriculumVitae, response) == false)
                    {
                        _lattesModule.DecrementProcessCount();
                        return;
                    }

                    DownloadXml(curriculumVitae, response);

                    if (curriculumVitae.NomeProfessor == null || curriculumVitae.NomeProfessor.Trim().Length == 0)
                    {
                        Logger.Info(String.Format("Curriculo {0} baixado", curriculumVitae.NumeroCurriculo));
                        return;
                    }

                    Logger.Info(String.Format("Curriculo {0} - {1} baixado", curriculumVitae.NumeroCurriculo, curriculumVitae.NomeProfessor));
                }
            }
            catch (WebException exception)
            {
                Logger.Error(String.Format("Erro ao realizar requisão: {0}\n{1}", exception.Message, exception.StackTrace));
                _lattesModule.DecrementProcessCount();
            }
            finally
            {
                _lattesModule.TickDownloadBar();
            }
        }

        private void DownloadXml(CurriculoEntry curriculumVitae, MetadataResponse response)
        {
            using (var wc = new WebClient())
            {
                var link = String.Format(_urlDownloadXml, response.CodRhCript);
                var stream = wc.OpenRead(link);

                if (File.Exists(_lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo)))
                {
                    File.Delete(_lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo));
                }

                var zis = new ZipInputStream(stream);
                zis.GetNextEntry();
                FileStream xml = new FileStream(_lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo), FileMode.CreateNew);
                using (xml)
                {
                    StreamUtils.Copy(zis, xml, new byte[4096]);
                    xml.Seek(0, SeekOrigin.Begin);
                }

                _curriculumVitaesForProcess.Send(curriculumVitae);
            }
        }

        private bool NeedsToBeUpdated(CurriculoEntry curriculumVitae, MetadataResponse response)
        {
            if (response.Document.DataAtualizacao == null || response.Document.DataAtualizacao.Length == 0)
            {
                return true;
            }

            var horaAtualizacao = response.Document.HoraAtualizacao;
            if (horaAtualizacao == null || horaAtualizacao.Length == 0)
            {
                horaAtualizacao = "000000";
            }

            var dataAtualizacaoLattes = DateTime.ParseExact(
                String.Format("{0} {1}", response.Document.DataAtualizacao, horaAtualizacao),
                "ddMMyyyy %Hmmss",
                null
            );

            if (dataAtualizacaoLattes == null)
            {
                return true;
            }

            var dataAtualizacaoCorrente = GetDataAtualizacaoProfessor(curriculumVitae.NumeroCurriculo);
            if (dataAtualizacaoCorrente == null)
            {
                return true;
            }

            if (dataAtualizacaoCorrente < dataAtualizacaoLattes)
            {
                return true;
            }

            return false;
        }

        private Nullable<DateTime> GetDataAtualizacaoProfessor(string numeroCurriculo)
        {
            var db = new LattesDatabase();
            var p = db.Professor.FirstOrDefault(prof => prof.NumeroCurriculo == numeroCurriculo);

            if (p == null)
            {
                return null;
            }

            return p.DataUltimaAtualizacaoCurriculo;
        }
    }

    [DataContract]
    internal class MetadataResponse
    {
        [DataMember(Name = "cod_rh_cript_s")]
        public string CodRhCript;
        [DataMember(Name = "docs")]
        public List<MetadataResponseDocument> Docs;

        public MetadataResponseDocument Document
        {
            get { return Docs[0]; }
        }
    }

    [DataContract]
    internal class MetadataResponseDocument
    {
        [DataMember(Name = "dataAtualizacao")]
        public string DataAtualizacao;
        [DataMember(Name = "horaAtualizacao")]
        public string HoraAtualizacao;
        [DataMember(Name = "numeroIdentificador")]
        public string NumeroIdentificador;
        [DataMember(Name = "dadosGerais")]
        public MetadataResponseGeneralData DadosGerais;

        public string NomeCompleto { get { return DadosGerais.NomeCompleto; } }
    }

    [DataContract]
    internal class MetadataResponseGeneralData
    {
        [DataMember(Name = "nomeCompleto")]
        public string NomeCompleto;
    }
}
