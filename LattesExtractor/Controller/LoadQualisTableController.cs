using LattesExtractor.DAO;
using LattesExtractor.Entities.CSV;
using LattesExtractor.Entities.Database;
using LINQtoCSV;
using log4net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LattesExtractor.Controller
{
    class LoadQualisTableController
    {

        private static readonly ILog Logger = LogManager.GetLogger(typeof(LoadQualisTableController).Name);

        public static void LoadQualisTable(LattesModule lattesModule)
        {
            LoadQualisTableCSV(lattesModule);
        }

        private static void LoadQualisTableCSV(LattesModule lattesModule)
        {
            QualisDAOService dao = new QualisDAOService(new LattesDatabase());

            CsvContext cc = new CsvContext();

            CsvFileDescription inputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ';',
                FirstLineHasColumnNames = true,
                FileCultureName = "pt-BR" // default is the current culture
            };
            
            IEnumerable<QualisCSV> qualisFile = cc.Read<QualisCSV>(
                new StreamReader(File.Open(lattesModule.QualisFileName, FileMode.Open),
                Encoding.GetEncoding("iso-8859-15")), inputFileDescription);

            var qualis = from q in qualisFile select q;

            dao.CreateQualis("00000000", "Não Informado", "NI", "Não Informado");

            foreach (var q in qualis)
            {
                dao.CreateQualis(q.ISSN, q.Titulo, q.Extrato, q.AreaAvaliacao);
            }
        }
    }
}
