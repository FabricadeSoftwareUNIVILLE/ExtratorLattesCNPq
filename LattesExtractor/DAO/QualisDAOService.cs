using LattesExtractor.Entities.Database;
using System.Linq;
using System.Text.RegularExpressions;

namespace LattesExtractor.DAO
{
    class QualisDAOService
    {
        private LattesDatabase LattesDatabase;
        private static Regex naoEhNumero = new Regex("([^0-9Xx])");

        public QualisDAOService(LattesDatabase db)
        {
            this.LattesDatabase = db;
        }

        public PeriodicoQualis CreateQualis(string issn, string titulo, string extrato, string areaAtuacao)
        {
            if (issn == null)
                issn = "";
            else
            {
                if (issn.Trim() != "")
                    issn = naoEhNumero.Replace(issn.Trim(), "");
            }

            PeriodicoQualis qualis = GetQualis(issn, titulo);

            if (qualis == null)
            {
                qualis = LattesDatabase.PeriodicoQualis.Create();

                qualis.ISSNPeriodicoQualis = Utils.SetMaxLength(issn, 8);
                qualis.TituloPeriodicoQualis = Utils.SetMaxLength(titulo, 200);
                
                LattesDatabase.PeriodicoQualis.Add(qualis);
            }

            ExtratoQualis extratoQualis = qualis.ExtratoQualis.FirstOrDefault(e => e.AreaAvaliacaoPeriodicoQualis == areaAtuacao);

            if (extratoQualis == null)
            {
                extratoQualis = LattesDatabase.ExtratoQualis.Create();
                extratoQualis.ExtratoPeriodicoQualis = extrato;
                extratoQualis.AreaAvaliacaoPeriodicoQualis = areaAtuacao;
                qualis.ExtratoQualis.Add(extratoQualis);
            } else
                extratoQualis.ExtratoPeriodicoQualis = extrato;

            LattesDatabase.SaveChanges();

            return qualis;
        }

        internal PeriodicoQualis GetQualis(string issn, string nomePeriodico)
        {
            PeriodicoQualis qualis = null;

            if (nomePeriodico == null)
                nomePeriodico = "";
            else
                nomePeriodico = nomePeriodico.Trim();

            if (issn == null || issn.Trim() == "")
            {
                qualis = LattesDatabase.PeriodicoQualis.FirstOrDefault(q => q.TituloPeriodicoQualis == nomePeriodico);
            }
            else
            {
                issn = naoEhNumero.Replace(issn.Trim(), "");
                qualis = LattesDatabase.PeriodicoQualis.FirstOrDefault(q => q.ISSNPeriodicoQualis == issn);
            }

            return qualis;
        }
    }
}
