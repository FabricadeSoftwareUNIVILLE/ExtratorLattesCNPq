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

namespace LattesExtractor.Controller
{
    class ImportCurriculumVitaeFromFolderController
    {
        private LattesModule lattesModule;

        private static readonly ILog Logger = LogManager.GetLogger(typeof(ImportCurriculumVitaeFromFolderController).Name);

        public static void LoadCurriculums(LattesModule lattesModule, string folder)
        {
            int read;
            byte[] buffer = new byte[4096];
            MemoryStream ms;
            CurriculoEntry curriculumVitae;

            if (!Directory.Exists(folder))
            {
                Logger.Info(String.Format("Pasta de trabalho não foi encontrado ({0})", folder));
                return;
            }

            bool exists = false;
            foreach(string filename in Directory.EnumerateFiles(folder))
            {
                exists = true;
                String numeroCurriculo = filename.Substring(folder.Length + 1);
                numeroCurriculo = numeroCurriculo.Substring(0, numeroCurriculo.Length - 4);
                curriculumVitae = new CurriculoEntry
                {
                    NumeroCurriculo = numeroCurriculo,
                };
                
                if (File.Exists(lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo)))
                    File.Delete(lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo));

                if (filename.EndsWith(".xml")) {
                    File.Copy(filename, lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo));
                    lattesModule.AddCurriculumVitaeForProcess(curriculumVitae);
                    continue;
                }

                ms = UnzipCurriculumVitae(filename);

                FileStream wc = new FileStream(lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo), FileMode.CreateNew);
                while ((read = ms.Read(buffer, 0, buffer.Length)) > 0)
                {
                    wc.Write(buffer, 0, read);
                }
                ms.Close();

                lattesModule.AddCurriculumVitaeForProcess(curriculumVitae);

            }

            if (exists == false)
            {
                throw new Exception(String.Format("Não foram encontrados currículos na pasta {0} !", folder));
            }
        }

        private static MemoryStream UnzipCurriculumVitae(string filename)
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
