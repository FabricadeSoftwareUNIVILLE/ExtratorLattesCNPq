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

        private Channel<RetryMessage> _retryDownload = new Channel<RetryMessage>();

        private int _pendingCurriculums = 0;

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
                ThreadPool.QueueUserWorkItem(o => RetryQueueProcessing(doneEvent));

                foreach (var c in _curriculumVitaesForDownload.Range())
                {
                    Interlocked.Increment(ref _pendingCurriculums);
                    _retryDownload.Send(
                        new RetryMessage
                        {
                            CurriculumVitae = c,
                            PendingRetries = 5,
                        }
                    );
                }

                if (_pendingCurriculums > 0)
                {
                    doneEvent.WaitOne();
                    doneEvent = null;
                }
            }
            finally
            {
                if (doneEvent != null)
                {
                    doneEvent.Set();
                }
                Logger.Info("Download terminou");
            }
        }

        private void RetryQueueProcessing(ManualResetEvent doneDownloadEvent)
        {
            foreach (var rm in _retryDownload.Range())
            {
                //ThreadPool.QueueUserWorkItem(o => 
                DownloadCurriculumVitae(rm, doneDownloadEvent)
                //)
                ;
            }
        }

        private void DownloadCurriculumVitae(RetryMessage retryMessage, ManualResetEvent doneDownloadEvent)
        {
            var curriculumVitae = retryMessage.CurriculumVitae;
            var wc = new WebClient();
            try
            {
                var stream = wc.OpenRead(String.Format(_urlMetadata, curriculumVitae.NumeroCurriculo));

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(MetadataResponse));
                var response = ser.ReadObject(stream) as MetadataResponse;

                if (response.CodRhCript == null || response.CodRhCript.Trim().Length == 0)
                {
                    Logger.Error($"Não foi possível baixar o currículo de número {curriculumVitae.NumeroCurriculo}");
                    return;
                }

                curriculumVitae.NomeProfessor = response.Document.NomeCompleto;

                if (NeedsToBeUpdated(curriculumVitae, response) == false)
                {
                    Logger.Info($"Currículo {curriculumVitae.NumeroCurriculo} - {curriculumVitae.NomeProfessor} já esta atualizado.");
                    return;
                }

                DownloadXml(curriculumVitae, response, wc);

                if (curriculumVitae.NomeProfessor == null || curriculumVitae.NomeProfessor.Trim().Length == 0)
                {
                    Logger.Info($"Curriculo {curriculumVitae.NumeroCurriculo} baixado");
                    return;
                }

                Logger.Info($"Curriculo {curriculumVitae.NumeroCurriculo} - {curriculumVitae.NomeProfessor} baixado");
            }
            catch (WebException exception)
            {
                Logger.Error(
                    $"Erro ao realizar requisão do Currículo {curriculumVitae.NumeroCurriculo} (Tentativas Sobrando {retryMessage.PendingRetries}): {exception.Message}\n{exception.StackTrace}"
                );
                retryMessage.PendingRetries--;
                if (retryMessage.PendingRetries > 0)
                {
                    Thread.Sleep(10000);
                    Interlocked.Increment(ref _pendingCurriculums);
                    _retryDownload.Send(retryMessage);
                }
            }
            finally
            {
                wc.Dispose();
                if (Interlocked.Decrement(ref _pendingCurriculums) == 0)
                {
                    doneDownloadEvent.Set();
                    _retryDownload.Close();
                }
            }
        }

        private void DownloadXml(CurriculoEntry curriculumVitae, MetadataResponse response, WebClient wc)
        {
            var link = String.Format(_urlDownloadXml, response.CodRhCript);
            Logger.Debug($"Currículo {curriculumVitae.NumeroCurriculo} marcado para download ({link})...");
            var stream = wc.OpenRead(link);

            if (File.Exists(_lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo)))
            {
                File.Delete(_lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo));
            }

            var zis = new ZipInputStream(stream);
            zis.GetNextEntry();
            FileStream xml = new FileStream(_lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo), FileMode.CreateNew);

            var buffer = new byte[4096];
            int read;
            while ((read = zis.Read(buffer, 0, buffer.Length)) > 0)
            {
                xml.Write(buffer, 0, read);
            }
            xml.Close();

            _curriculumVitaesForProcess.Send(curriculumVitae);
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
                $"{response.Document.DataAtualizacao} {horaAtualizacao}",
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

    class TimeoutWebClient : WebClient
    {
        public int Timeout = 0;

        public TimeoutWebClient(int timeout) : base ()
        {
            Timeout = timeout;
        }

        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest w = base.GetWebRequest(uri);
            if (Timeout > 0)
            {
                w.Timeout = Timeout;
            }
            return w;
        }
    }

    internal class RetryMessage
    {
        public CurriculoEntry CurriculumVitae;
        public int PendingRetries = 5;
    }

#pragma warning disable CS0649
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
#pragma warning restore CS0649
}
