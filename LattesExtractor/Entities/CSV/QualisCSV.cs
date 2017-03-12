using LINQtoCSV;

namespace LattesExtractor.Entities.CSV
{
    class QualisCSV
    {
#pragma warning disable CS0649 // Async method lacks 'await' operators and will run synchronously
        [CsvColumn(FieldIndex = 1)]
        public string ISSN;

        [CsvColumn(Name = "TITULO", FieldIndex = 2)]
        public string Titulo;

        [CsvColumn(Name = "EXTRATO", FieldIndex = 3)]
        public string Extrato;

        [CsvColumn(Name = "AREA DE AVALIACAO", FieldIndex = 4)]
        public string AreaAvaliacao;

        [CsvColumn(Name = "STATUS", FieldIndex = 5)]
        public string Status;
#pragma warning restore CS0649 // Async method lacks 'await' operators and will run synchronously
    }
}
