using LattesExtractor.Collections;
using LattesExtractor.Entities;
using System.Data;
using System.Data.OleDb;
using System.Threading;

namespace LattesExtractor.Controller
{
    class LoadCurriculumVitaeNumberFromOleDbController
    {
        private LattesModule _lattesModule;
        private Channel<CurriculoEntry> _channel;
        private string _query;
        private string _connectionString;

        public LoadCurriculumVitaeNumberFromOleDbController(LattesModule lattesModule, string connectionString, string query, Channel<CurriculoEntry> channel)
        {
            _lattesModule = lattesModule;
            _connectionString = connectionString;
            _query = query;
            _channel = channel;
        }

        public void LoadCurriculumVitaeNumbers(object threadContext)
        {
            ManualResetEvent doneEvent = (ManualResetEvent)threadContext;
            try
            {
                DataTable dataTable = new DataTable();
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(_query, _connectionString))
                {
                    adapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (dataTable.Columns.Count == 1)
                        {
                            AddToChannel(
                                new CurriculoEntry()
                                {
                                    NumeroCurriculo = row[dataTable.Columns[0]].ToString().Trim(),
                                }
                            );
                            continue;
                        }

                        if (dataTable.Columns.Count == 2)
                        {
                            AddToChannel(
                                new CurriculoEntry()
                                {
                                    NumeroCurriculo = row[dataTable.Columns[0]].ToString().Trim(),
                                    NomeProfessor = row[dataTable.Columns[1]].ToString().Trim(),
                                }
                            );
                            continue;

                        }

                        if (dataTable.Columns.Count == 3)
                        {
                            AddToChannel(
                                new CurriculoEntry()
                                {
                                    NomeProfessor = row[dataTable.Columns[0]].ToString().Trim(),
                                    DataNascimento = row[dataTable.Columns[1]].ToString().Trim(),
                                    CPF = row[dataTable.Columns[2]].ToString().Trim(),
                                    NumeroCurriculo = "",
                                }
                            );
                            continue;
                        }

                        if (dataTable.Columns.Count == 4)
                        {
                            AddToChannel(
                                new CurriculoEntry()
                                {
                                    NumeroCurriculo = row[dataTable.Columns[0]].ToString().Trim(),
                                    NomeProfessor = row[dataTable.Columns[1]].ToString().Trim(),
                                    DataNascimento = row[dataTable.Columns[2]].ToString().Trim(),
                                    CPF = row[dataTable.Columns[3]].ToString().Trim(),
                                }
                            );
                            continue;
                        }
                    }
                }
            }
            finally
            {
                doneEvent.Set();
            }
        }

        private void AddToChannel(CurriculoEntry ce)
        {
            if (
                (ce.NumeroCurriculo != null && ce.NumeroCurriculo.Length > 0) || (
                    ce.NomeProfessor != null && ce.NomeProfessor.Length > 0 && 
                    ce.DataNascimento != null && ce.DataNascimento.Length > 0 &&
                    ce.CPF != null && ce.CPF.Length > 0
                )
            )
            {
                _lattesModule.IncrementDownloadCount();
                _channel.Send(ce);
            }
        }
    }
}
