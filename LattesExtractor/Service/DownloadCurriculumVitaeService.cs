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
    class DownloadCurriculumVitaeService
    {
        protected LattesDatabase db;
        protected WSCurriculoClient ws;

        private static readonly ILog Logger = LogManager.GetLogger(typeof(DownloadCurriculumVitaeService).Name);

        public DownloadCurriculumVitaeService(LattesDatabase db, WSCurriculoClient ws)
        {
            this.db = db;
            this.ws = ws;
        }

        public MemoryStream GetCurriculumVitaeIfUpdated(CurriculoEntry curriculumVitae)
        {
            Nullable<DateTime> dataAtualizacaoLattes = null;
            Nullable<DateTime> dataAtualizacaoSistema;
            string dataAtualizacaoString;

            if (curriculumVitae.NumeroCurriculo == null || curriculumVitae.NumeroCurriculo == "")
            {
                Logger.Info(String.Format("Buscando Número do Currículo do Professor {0}", curriculumVitae.NomeProfessor));
                curriculumVitae.NumeroCurriculo = ws.getIdentificadorCNPq(curriculumVitae.CPF, curriculumVitae.NomeProfessor, curriculumVitae.DataNascimento);

                if (curriculumVitae.NumeroCurriculo == null || curriculumVitae.NumeroCurriculo == "" || curriculumVitae.NumeroCurriculo.Contains("ERRO"))
                    return null;

                Logger.Info(String.Format("Número do Currículo do Professor {0} encontrado: {1}", curriculumVitae.NomeProfessor, curriculumVitae.NumeroCurriculo));
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
                Logger.Error(String.Format("Aconteceu um erro ao tentar buscar o currículo de Número {0}, favor verificar o mesmo", curriculumVitae.NumeroCurriculo));
                return null;
            }

            return ProcessarRetornoCurriculo(zip);
        }

        private MemoryStream ProcessarRetornoCurriculo(byte[] curriculo)
        {
            ZipInputStream zis;
            MemoryStream xml;

            zis = new ZipInputStream(new MemoryStream(curriculo));
            zis.GetNextEntry();
            xml = new MemoryStream();

            StreamUtils.Copy(zis, xml, new byte[4096]);
            xml.Seek(0, SeekOrigin.Begin);

            return xml;
        }

        private Nullable<DateTime> GetDataAtualizacaoProfessor(string numeroCurriculo)
        {
            var p = db.Professor.FirstOrDefault(prof => prof.NumeroCurriculo == numeroCurriculo);

            if (p == null)
                return null;
            else
                return p.DataUltimaAtualizacaoCurriculo;
        }
    }
}
