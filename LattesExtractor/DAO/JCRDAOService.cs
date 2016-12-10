using LattesExtractor.Entities.Database;
using System;
using System.Linq;

namespace LattesExtractor.DAO
{
    class JCRDAOService
    {
        public LattesDatabase LattesDatabase;

        public JCRDAOService(LattesDatabase db)
        {
            this.LattesDatabase = db;
        }

        public JCR CreateJCR(string issn, string nomePeriodico, string nomeAbreviado, int rank, Nullable<int> numeroCitacoes, Nullable<decimal> fatorImpacto,
            Nullable<decimal> fatorImpactoSemCitacoesProprias, Nullable<decimal> fatorImpactoCincoAnos, Nullable<decimal> indiceInfluencia,
            Nullable<int> itensCitaveis, Nullable<decimal> pontuacaoEigenfactor, Nullable<decimal> pontuacaoInfluenciaArtigo, Nullable<decimal> percentualMedio, Nullable<decimal> eigenfactorNormalizado)
        {

            if (issn == null)
                issn = "";
            else
            {
                if (issn.Trim() != "")
                    issn = Utils.CleanISSN(issn);
            }

            JCR jcr = GetJCR(issn, nomePeriodico);

            if (jcr == null)
            {
                jcr = LattesDatabase.JCR.Create();
                jcr.NomePeriodicoJCR = nomePeriodico;
                jcr.ISSNJCR = issn;

                LattesDatabase.JCR.Add(jcr);
            }

            jcr.NomeAbreviadoPeriodioJCR = nomeAbreviado;
            jcr.Rank = rank;
            jcr.NumeroCitacoesJCR = numeroCitacoes;
            jcr.FatorImpactoJCR = fatorImpacto;
            jcr.FatorImpactoSemCitacoesPropriasJCR = fatorImpactoSemCitacoesProprias;
            jcr.FatorImpactoCincoAnosJCR = fatorImpactoCincoAnos;
            jcr.IndiceInfluenciaJCR = indiceInfluencia;
            jcr.ItensCitaveisJCR = itensCitaveis;
            jcr.PontuacaoEigenfactorJCR = pontuacaoEigenfactor;
            jcr.PontuacaoInfluenciaArtigoJCR = pontuacaoInfluenciaArtigo;
            jcr.PercentualMedioJCR = percentualMedio;
            jcr.EigenfactorNormalizadoJCR = eigenfactorNormalizado;

            LattesDatabase.SaveChanges();

            return jcr;
        }

        public JCR GetJCR(string issn, string nomePeriodico)
        {
            JCR jcr = null;

            if (nomePeriodico == null)
                nomePeriodico = "";
            else
                nomePeriodico = nomePeriodico.Trim();

            if (issn == null || issn.Trim() == "")
            {
                jcr = LattesDatabase.JCR.FirstOrDefault(q => q.NomePeriodicoJCR == nomePeriodico);
            }
            else
            {
                issn = Utils.CleanISSN(issn);
                jcr = LattesDatabase.JCR.FirstOrDefault(q => q.ISSNJCR == issn);
            }

            return jcr;
        }
    }
}
