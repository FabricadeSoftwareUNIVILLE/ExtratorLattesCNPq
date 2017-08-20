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
        private LattesModule _lattesModule;
        private Channel<CurriculoEntry> _channel;
        private string _filename;

        public LoadCurriculumVitaeNumberFromCSVController(LattesModule lattesModule, string filename, Channel<CurriculoEntry> channel)
        {
            _lattesModule = lattesModule;
            _filename = filename;
            _channel = channel;
        }

        public void LoadCurriculumVitaeNumbers(ManualResetEvent doneEvent)
        {
            try
            {
                CsvContext cc = new CsvContext();

                CsvFileDescription inputFileDescription = new CsvFileDescription
                {
                    SeparatorChar = ';',
                    FirstLineHasColumnNames = true,
                    EnforceCsvColumnAttribute = true,
                    FileCultureName = "pt-BR", // default is the current culture
                    IgnoreTrailingSeparatorChar = true,
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
                    _lattesModule.IncrementDownloadCount();
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
        public String NumeroCurriculo;
        [CsvColumn(FieldIndex = 2, CanBeNull = true, Name = "NomeProfessor")]
        public String NomeProfessor;
        [CsvColumn(FieldIndex = 3, CanBeNull = true, Name = "DataNascimento")]
        public String DataNascimento;
        [CsvColumn(FieldIndex = 4, CanBeNull = true, Name = "CPF")]
        public String CPF;
    }
}
