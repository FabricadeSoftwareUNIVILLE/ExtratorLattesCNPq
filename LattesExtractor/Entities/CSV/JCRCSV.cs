using LINQtoCSV;
using System;

namespace LattesExtractor.Entities.CSV
{
    class JCRCSV
    {
#pragma warning disable CS0649
        [CsvColumn(FieldIndex = 1, Name = "Rank")]
        public String Rank;
        [CsvColumn(FieldIndex = 2, Name = "Full Journal Title")]
        public String FullJournalTitle;
        [CsvColumn(FieldIndex = 3, Name = "JCR Abbreviated Title")]
        public String JCRAbbreviatedTitle;
        [CsvColumn(FieldIndex = 4, Name = "Issn")]
        public String Issn;
        [CsvColumn(FieldIndex = 5, Name = "Total Cites")]
        public String TotalCites;
        [CsvColumn(FieldIndex = 6, Name = "Journal Impact Factor")]
        public String JournalImpactFactor;
        [CsvColumn(FieldIndex = 7, Name = "Impact Factor without Journal Self Cites")]
        public String ImpactFactorWithoutJournalSelfCites;
        [CsvColumn(FieldIndex = 8, Name = "5-Year Impact Factor")]
        public String FiveYearImpactFactor;
        [CsvColumn(FieldIndex = 9, Name = "Immediacy Index")]
        public String ImmediacyIndex;
        [CsvColumn(FieldIndex = 10, Name = "Citable Items")]
        public String CitableItems;
        [CsvColumn(FieldIndex = 11, Name = "Cited Half-life")]
        public String CitedHalfLife;
        [CsvColumn(FieldIndex = 12, Name = "Citing Half-life")]
        public String CitingHalfLife;
        [CsvColumn(FieldIndex = 13, Name = "Eigenfactor Score")]
        public String EigenfactorScore;
        [CsvColumn(FieldIndex = 14, Name = "Article Influence Score")]
        public String ArticleInfluenceScore;
        [CsvColumn(FieldIndex = 15, Name = "% Articles in Citable Items")]
        public String PercArticlesInCitableItems;
        [CsvColumn(FieldIndex = 16)]
        public String BlankColumn;
        [CsvColumn(FieldIndex = 17, Name = "Average Journal Impact Factor Percentile")]
        public String AverageJournalImpactFactorPercentile;
        [CsvColumn(FieldIndex = 18, Name = "Normalized Eigenfactor")]
        public String NormalizedEigenfactor;
#pragma warning restore CS0649
    }
}
