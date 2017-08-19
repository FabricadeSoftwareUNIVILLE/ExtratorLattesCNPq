using LattesExtractor.Collections;
using LattesExtractor.Entities;
using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LattesExtractor.Controller
{
    class LoadCurriculumVitaeNumberFromCSVController
    {
        private Channel<CurriculoEntry> _channel;
        private string _filename;

        public LoadCurriculumVitaeNumberFromCSVController(string filename, Channel<CurriculoEntry> channel)
        {
            _filename = filename;
            _channel = channel;
        }

        public void LoadCurriculumVitaeNumbers(object threadContext)
        {
            ManualResetEvent doneEvent = (ManualResetEvent)threadContext;
            try
            {
                CsvContext cc = new CsvContext();

                CsvFileDescription inputFileDescription = new CsvFileDescription
                {
                    SeparatorChar = ';',
                    FirstLineHasColumnNames = true,
                    EnforceCsvColumnAttribute = true,
                    FileCultureName = "pt-BR" // default is the current culture
                };

                var rows = cc.Read<CSVResume>(
                    new StreamReader(
                        File.Open(_filename, FileMode.Open),
                        Encoding.GetEncoding("iso-8859-15")
                    ),
                    inputFileDescription
                );

                foreach (var row in rows)
                {
                    _channel.Send(
                        new CurriculoEntry
                        {
                            NumeroCurriculo = row.NumeroCurriculo,
                            NomeProfessor = row.NomeProfessor,
                            DataNascimento = row.DataNascimento,
                            CPF = row.CPF,
                        }
                    );
                }
            }
            finally
            {
                doneEvent.Set();
            }
        }
    }

    class CSVResume
    {
        [CsvColumn(FieldIndex = 1, CanBeNull = true, Name = "NumeroCurriculo")]
        public string NumeroCurriculo;
        [CsvColumn(FieldIndex = 2, CanBeNull = true, Name = "NomeProcessor")]
        public string NomeProfessor;
        [CsvColumn(FieldIndex = 3, CanBeNull = true, Name = "DataNascimento")]
        public string DataNascimento;
        [CsvColumn(FieldIndex = 4, CanBeNull = true, Name = "CPF")]
        public string CPF;
    }
}
