using LattesExtractor.DAO;
using LattesExtractor.Entities.CSV;
using LattesExtractor.Entities.Database;
using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LattesExtractor.Controller
{
    class LoadJCRTableController
    {
        public static void LoadJCRTable(LattesModule lattesModule)
        {
            LoadJCRTableCSV(lattesModule);
        }

        private static void LoadJCRTableCSV(LattesModule lattesModule)
        {
            JCRDAOService dao = new JCRDAOService(new LattesDatabase());

            CsvContext cc = new CsvContext();

            CsvFileDescription inputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = false,
                EnforceCsvColumnAttribute = true,
                FileCultureName = "pt-BR" // default is the current culture
            };

            IEnumerable<JCRCSV> jcrFile = cc.Read<JCRCSV>(
                new StreamReader(File.Open(lattesModule.JCRFileName, FileMode.Open),
                Encoding.GetEncoding("iso-8859-15")), inputFileDescription);

            var jcrQuery = from q in jcrFile select q;

            dao.CreateJCR("00000000", "Não Informado", "Não Informado", 0,
                null, null, null, null, null, null, null, null, null, null);
            
            foreach (var jcr in jcrQuery)
            {
                if (jcr.Rank == "Rank" 
                    || jcr.Rank.StartsWith("Journal Data Filtered By")
                    || jcr.Rank.StartsWith("Copyright"))
                    continue;

                if (jcr.CitedHalfLife == ">10.0")
                    jcr.CitedHalfLife = "11.0";

                if (jcr.CitingHalfLife == ">10.0")
                    jcr.CitingHalfLife = "11.0";

                dao.CreateJCR(jcr.Issn,
                              jcr.FullJournalTitle,
                              jcr.JCRAbbreviatedTitle,
                              ToInt(jcr.Rank),
                              ToInt(jcr.TotalCites),
                              ToNullableDecimal(jcr.JournalImpactFactor),
                              ToNullableDecimal(jcr.ImpactFactorWithoutJournalSelfCites),
                              ToNullableDecimal(jcr.FiveYearImpactFactor),
                              ToNullableDecimal(jcr.ImmediacyIndex),
                              ToNullableInt(jcr.CitableItems),
                              ToNullableDecimal(jcr.EigenfactorScore),
                              ToNullableDecimal(jcr.ArticleInfluenceScore),
                              ToNullableDecimal(jcr.AverageJournalImpactFactorPercentile),
                              ToNullableDecimal(jcr.NormalizedEigenfactor));
            }
        }

        public static Nullable<decimal> ToNullableDecimal(string str)
        {
            if (str == null || str == "" || str == "Not Available")
                return null;

            return decimal.Parse(AdjustNumbers(str));
        }
        public static int ToInt(string str)
        {
            if (str == null || str == "" || str == "Not Available")
                return 0;

            return int.Parse(AdjustNumbers(str));
        }
        public static Nullable<int> ToNullableInt(string str)
        {
            if (str == null || str == "" || str == "Not Available")
                return null;

            return int.Parse(AdjustNumbers(str));
        }

        public static string AdjustNumbers(string str)
        {
            return str.Replace(",", "").Replace(".", ",");
        }
    }
}