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
    class LoadFromTempDirectory
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(LoadFromTempDirectory).Name);

        public static void LoadCurriculums(LattesModule lattesModule)
        {
            bool exists = false;
            foreach(string filename in Directory.EnumerateFiles(lattesModule.TempDirectory))
            {
                string numeroCurriculo = filename.Substring(lattesModule.TempDirectory.Length + 1);
                numeroCurriculo = numeroCurriculo.Substring(0, numeroCurriculo.Length - 4);
                lattesModule.AddCurriculumVitaeForProcess(new CurriculoEntry
                {
                    NumeroCurriculo = numeroCurriculo,
                });

                exists = true;
            }

            if (exists)
            {
                Logger.Info(String.Format("Foram encontrados XMLs pendentes na pasta '{0}' !'", lattesModule.TempDirectory));
                return;
            }

        }
    }
}
