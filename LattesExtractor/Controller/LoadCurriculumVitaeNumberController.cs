using LattesExtractor.Entities;
using System;
using System.Data;
using System.Data.OleDb;

namespace LattesExtractor.Controller
{
    class LoadCurriculumVitaeNumberController
    {
        internal static void LoadCurriculumVitaeNumbers(LattesModule lattesModule)
        {
            // ler do banco de dados do RM para pegar os profissionais

            // Criando adaptador que busca todos os registros da planilha
            DataTable dataTable = new DataTable();
            
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(lattesModule.LattesCurriculumVitaeQuery, lattesModule.LattesCurriculumVitaeODBCConnection))
            {
                CurriculoEntry ce;
                adapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    ce = null;
                    if (dataTable.Columns.Count == 1)
                    {
                        ce = new CurriculoEntry()
                        {
                            NumeroCurriculo = row[dataTable.Columns[0]].ToString().Trim(),
                        };
                    }
                    else
                    {
                        if (dataTable.Columns.Count == 2)
                        {
                            ce = new CurriculoEntry()
                            {
                                NumeroCurriculo = row[dataTable.Columns[0]].ToString().Trim(),
                                NomeProfessor = row[dataTable.Columns[1]].ToString().Trim(),
                            };
                        }
                        else
                        {
                            if (dataTable.Columns.Count == 3)
                            {
                                ce = new CurriculoEntry()
                                {
                                    NomeProfessor = row[dataTable.Columns[0]].ToString().Trim(),
                                    DataNascimento = row[dataTable.Columns[1]].ToString().Trim(),
                                    CPF = row[dataTable.Columns[2]].ToString().Trim(),
                                    NumeroCurriculo = "",
                                };
                            } else
                            {
                                if (dataTable.Columns.Count == 4)
                                {
                                    ce = new CurriculoEntry()
                                    {
                                        NumeroCurriculo = row[dataTable.Columns[0]].ToString().Trim(),
                                        NomeProfessor = row[dataTable.Columns[1]].ToString().Trim(),
                                        DataNascimento = row[dataTable.Columns[2]].ToString().Trim(),
                                        CPF = row[dataTable.Columns[3]].ToString().Trim(),
                                    };
                                }
                            }
                        }
                    }

                    if (ce != null
                        && ((ce.NumeroCurriculo != null && ce.NumeroCurriculo.Length > 0)
                        || (ce.NomeProfessor != null && ce.NomeProfessor.Length > 0
                         && ce.DataNascimento != null && ce.DataNascimento.Length > 0)
                         && ce.CPF != null && ce.CPF.Length > 0))
                        lattesModule.AddCurriculumVitaeNumberToDownload(ce);
                }
            }
        }
    }
}
