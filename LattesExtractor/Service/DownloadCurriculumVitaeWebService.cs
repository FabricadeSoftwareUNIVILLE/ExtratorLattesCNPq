using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using LattesExtractor.CurriculoLattesWebService;
using LattesExtractor.Entities;
using LattesExtractor.Entities.Database;
using log4net;
using System;
using System.IO;
using System.Linq;

namespace LattesExtractor.Service
{
    class DownloadCurriculumVitaeWebService
    {
//        protected LattesDatabase db;
        protected WSCurriculoClient ws;

        private static readonly ILog Logger = LogManager.GetLogger(typeof(DownloadCurriculumVitaeWebService).Name);

        public DownloadCurriculumVitaeWebService(LattesDatabase db, WSCurriculoClient ws)
        {
            //this.db = db;
            this.ws = ws;
        }

        public MemoryStream GetCurriculumVitaeIfUpdated(CurriculoEntry curriculumVitae)
        {
            Nullable<DateTime> dataAtualizacaoLattes = null;
            Nullable<DateTime> dataAtualizacaoSistema;
            string dataAtualizacaoString;

            if (curriculumVitae.NumeroCurriculo == null || curriculumVitae.NumeroCurriculo == "")
            {
                Logger.Info(
                    $"Buscando Número do Currículo do Professor {curriculumVitae.NomeProfessor}"
                );
                curriculumVitae.NumeroCurriculo = ws.getIdentificadorCNPq(curriculumVitae.CPF, curriculumVitae.NomeProfessor, curriculumVitae.DataNascimento);

                if (curriculumVitae.NumeroCurriculo == null || curriculumVitae.NumeroCurriculo == "" || curriculumVitae.NumeroCurriculo.Contains("ERRO"))
                    return null;

                Logger.Info(
                    $"Número do Currículo do Professor {curriculumVitae.NomeProfessor} encontrado: {curriculumVitae.NumeroCurriculo}"
                );
            }

            // verificar se a data de atualizacao do CV é maior que a do sistema

            dataAtualizacaoSistema = this.GetDataAtualizacaoProfessor(curriculumVitae.NumeroCurriculo);

            if (dataAtualizacaoSistema != null)
            {
                dataAtualizacaoString = ws.getDataAtualizacaoCV(curriculumVitae.NumeroCurriculo);

                if (dataAtualizacaoString == "")
                    dataAtualizacaoLattes = DateTime.Today;
                else
                    dataAtualizacaoLattes = DateTime.ParseExact(dataAtualizacaoString, "dd/MM/yyyy %H:mm:ss", null);

                if (dataAtualizacaoSistema >= dataAtualizacaoLattes)
                    return null; // curriculo não precisa curriculumVitaeUnserializer atualizado
            }

            if (dataAtualizacaoLattes != null)
                curriculumVitae.DataUltimaAtualizacao = (DateTime)dataAtualizacaoLattes;

            byte[] zip = ws.getCurriculoCompactado(curriculumVitae.NumeroCurriculo);

            if (zip == null || zip.Length == 0)
            {
                Logger.Error(
                    $"Aconteceu um erro ao tentar buscar o currículo de Número {curriculumVitae.NumeroCurriculo}, favor verificar o mesmo"
                );
                return null;
            }

            return ProcessarRetornoCurriculo(zip);
        }

        private MemoryStream ProcessarRetornoCurriculo(byte[] curriculo)
        {
            var zis = new ZipInputStream(new MemoryStream(curriculo));
            zis.GetNextEntry();
            var xml = new MemoryStream();

            StreamUtils.Copy(zis, xml, new byte[4096]);
            xml.Seek(0, SeekOrigin.Begin);

            return xml;
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
}
