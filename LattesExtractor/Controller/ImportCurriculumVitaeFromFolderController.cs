using LattesExtractor.Entities.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using LattesExtractor.Service;
using log4net;
using LattesExtractor.Entities;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using LattesExtractor.Collections;

namespace LattesExtractor.Controller
{
    class ImportCurriculumVitaeFromFolderController
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ImportCurriculumVitaeFromFolderController).Name);

        private LattesModule _lattesModule;
        private string _importFolder;
        private Channel<CurriculoEntry> _channel;
        private int _workItemCount = 0;

        public ImportCurriculumVitaeFromFolderController(
            LattesModule lattesModule,
            string importFolder,
            Channel<CurriculoEntry> channel
        )
        {
            _lattesModule = lattesModule;
            _importFolder = importFolder;
            _channel = channel;
        }

        public void LoadCurriculums(ManualResetEvent doneEvent)
        {
            try
            {
                if (!Directory.Exists(_importFolder))
                {
                    Logger.Info(String.Format("Pasta de trabalho não foi encontrado ({0})", _importFolder));
                    return;
                }

                if (Directory.GetFiles(_importFolder).Length == 0)
                {
                    throw new Exception(String.Format("Não foram encontrados currículos na pasta {0} !", _importFolder));
                }

                CurriculoEntry curriculumVitae;
                var unzipDoneEvent = new ManualResetEvent(false);

                foreach (string filename in Directory.EnumerateFiles(_importFolder))
                {
                    string numeroCurriculo = filename.Substring(_importFolder.Length + 1);
                    numeroCurriculo = numeroCurriculo.Substring(0, numeroCurriculo.Length - 4);
                    curriculumVitae = new CurriculoEntry { NumeroCurriculo = numeroCurriculo };

                    if (File.Exists(_lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo)))
                    {
                        File.Delete(_lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo));
                    }

                    if (filename.EndsWith(".xml"))
                    {
                        File.Copy(filename, _lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo));
                        _channel.Send(curriculumVitae);
                        _lattesModule.IncrementProcessCount();
                        continue;
                    }

                    Interlocked.Increment(ref _workItemCount);
                    ThreadPool.QueueUserWorkItem(o => UnzipAndCopy(unzipDoneEvent, filename, curriculumVitae));
                }
                if (_workItemCount > 0)
                {
                    unzipDoneEvent.WaitOne();
                }
            }
            finally
            {
                doneEvent.Set();
            }
        }

        private void UnzipAndCopy (ManualResetEvent doneEvent, string filename, CurriculoEntry curriculumVitae)
        {
            int read;
            byte[] buffer = new byte[4096];
            MemoryStream ms;

            ms = UnzipCurriculumVitae(filename);

            if (File.Exists(_lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo)))
            {
                File.Delete(_lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo));
            }
            FileStream wc = new FileStream(
                _lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo),
                FileMode.CreateNew
            );
            while ((read = ms.Read(buffer, 0, buffer.Length)) > 0)
            {
                wc.Write(buffer, 0, read);
            }
            ms.Close();
            _channel.Send(curriculumVitae);
            _lattesModule.IncrementProcessCount();

            if (Interlocked.Decrement(ref _workItemCount) == 0)
            {
                doneEvent.Set();
            }
        }

        private MemoryStream UnzipCurriculumVitae(string filename)
        {
            ZipInputStream zis;
            MemoryStream xml;

            zis = new ZipInputStream(new FileStream(filename, FileMode.Open));
            zis.GetNextEntry();
            xml = new MemoryStream();

            StreamUtils.Copy(zis, xml, new byte[4096]);
            xml.Seek(0, SeekOrigin.Begin);

            return xml;
        }
    }
}
