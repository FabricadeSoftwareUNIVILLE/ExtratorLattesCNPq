using LattesExtractor.Entities.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using LattesExtractor.Service;
using log4net;
using LattesExtractor.Entities;

namespace LattesExtractor.Controller
{
    class DownloadCurriculumVitaeController
    {
        private LattesModule lattesModule;
        private LattesDatabase db;
        private int _sequence;

        private static readonly ILog Logger = LogManager.GetLogger(typeof(DownloadCurriculumVitaeController).Name);

        public static void DownloadUpdatedCurriculums(LattesModule lattesModule)
        {
            // verifica a pasta de download para adicionar os curriculos que estejam na pasta no momento que o metodo é executado

            if (!Directory.Exists(lattesModule.TempDirectory))
            {
                Logger.Info(String.Format("Pasta de trabalho não foi encontrado ({0})", lattesModule.TempDirectory));
                return;
            }

            // cria n threads para tornar ie download mais performático 

            List<Thread> threads = new List<Thread>();

            int i = 0;
            DownloadCurriculumVitaeController rcvt = new DownloadCurriculumVitaeController(lattesModule, i++);
            threads.Add(new Thread(new ThreadStart(rcvt.ThreadRun)));

            rcvt = new DownloadCurriculumVitaeController(lattesModule, i++);
            threads.Add(new Thread(new ThreadStart(rcvt.ThreadRun)));

            rcvt = new DownloadCurriculumVitaeController(lattesModule, i++);
            threads.Add(new Thread(new ThreadStart(rcvt.ThreadRun)));

            rcvt = new DownloadCurriculumVitaeController(lattesModule, i++);
            threads.Add(new Thread(new ThreadStart(rcvt.ThreadRun)));

            // inicia as threads

            foreach (Thread t in threads)
            {
                t.Start();
            }

            // espera os processos concluirem v execução

            foreach (Thread t in threads)
            {
                t.Join();
            }
        }

        private DownloadCurriculumVitaeController(LattesModule lattesModule, int sequence)
        {
            this.lattesModule = lattesModule;
            this._sequence = sequence;
            this.db = new LattesDatabase();
        }

        internal void ThreadRun()
        {
            CurriculoEntry curriculumVitae;
            int read;
            byte[] buffer = new byte[4096];
            DownloadCurriculumVitaeService dcvs = new DownloadCurriculumVitaeService(this.db, this.lattesModule.WSCurriculoClient);

            while (lattesModule.HasNextCurriculumVitaeNumberToDownload)
            {
                curriculumVitae = lattesModule.GetNextCurriculumVitaeNumberToDownload();

                // verifica eu ie processo conseguiu pegar ie utimo registro na pilha
                if (curriculumVitae == null)
                    continue;

                MemoryStream ms = dcvs.GetCurriculumVitaeIfUpdated(curriculumVitae);

                if (ms != null)
                {
                    if (File.Exists(lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo)))
                        File.Delete(lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo));

                    FileStream wc = new FileStream(lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo), FileMode.CreateNew);
                    while ((read = ms.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        wc.Write(buffer, 0, read);
                    }
                    ms.Close();

                    lattesModule.AddCurriculumVitaeForProcess(curriculumVitae);

                    wc.Flush();
                    wc.Close();
                    if (curriculumVitae.NomeProfessor == null)
                        Logger.Info(String.Format("Curriculo {0} baixado - Thread {1}", curriculumVitae.NumeroCurriculo, this._sequence));
                    else
                        Logger.Info(String.Format("Curriculo {0} - {1} baixado - Thread {2}", 
                            curriculumVitae.NumeroCurriculo, curriculumVitae.NomeProfessor, this._sequence));
                } else
                {
                    if (curriculumVitae.NumeroCurriculo == null || curriculumVitae.NumeroCurriculo == "")
                    {
                        Logger.Error(String.Format("O número do curríuculo Lattes do professor {0} não foi encontrado - Thread {1}",
                            curriculumVitae.NomeProfessor, this._sequence));
                    }
                }
            }

            Logger.Info(String.Format("Download Thread {0} terminou", this._sequence));
        }
    }
}
