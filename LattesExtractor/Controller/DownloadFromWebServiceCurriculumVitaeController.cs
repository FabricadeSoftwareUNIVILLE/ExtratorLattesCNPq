using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using LattesExtractor.Service;
using log4net;
using LattesExtractor.Entities;
using LattesExtractor.Collections;

namespace LattesExtractor.Controller
{
    class DownloadFromWebServiceCurriculumVitaeController
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(DownloadFromWebServiceCurriculumVitaeController).Name);

        private LattesModule _lattesModule;
        private DownloadCurriculumVitaeWebService _dcvs;
        private Channel<CurriculoEntry> _curriculumVitaesForDownload;
        private Channel<CurriculoEntry> _curriculumVitaesForProcess;

        public DownloadFromWebServiceCurriculumVitaeController(
            LattesModule lattesModule,
            DownloadCurriculumVitaeWebService downloadCurriculumVitaeService,
            Channel<CurriculoEntry> curriculumVitaesForDownload,
            Channel<CurriculoEntry> curriculumVitaesForProcess
        )
        {
            _lattesModule = lattesModule;
            _dcvs = downloadCurriculumVitaeService;
            _curriculumVitaesForDownload = curriculumVitaesForDownload;
            _curriculumVitaesForProcess = curriculumVitaesForProcess;
        }

        public void DownloadUpdatedCurriculums(ManualResetEvent doneEvent)
        {
            try
            {
                foreach (var curriculumVitae in _curriculumVitaesForDownload.Range())
                {
                    DownloadCurriculumVitae(curriculumVitae);
                }
            }
            finally
            {
                doneEvent.Set();
                Logger.Info(String.Format("Download terminou"));
            }
        }

        private void DownloadCurriculumVitae(CurriculoEntry curriculumVitae)
        {
            try
            {
                if (curriculumVitae.NumeroCurriculo == null || curriculumVitae.NumeroCurriculo.Trim().Length == 0)
                {
                    Logger.Error(String.Format(
                        "O número do curríuculo Lattes do professor {0} não foi encontrado",
                        curriculumVitae.NomeProfessor
                    ));
                    _lattesModule.DecrementProcessCount();
                    return;
                }

                int read;
                byte[] buffer = new byte[4096];
                MemoryStream ms = _dcvs.GetCurriculumVitaeIfUpdated(curriculumVitae);

                if (ms == null)
                {
                    _lattesModule.DecrementProcessCount();
                    return;
                }

                if (File.Exists(_lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo)))
                {
                    File.Delete(_lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo));
                }

                FileStream wc = new FileStream(_lattesModule.GetCurriculumVitaeFileName(curriculumVitae.NumeroCurriculo), FileMode.CreateNew);
                while ((read = ms.Read(buffer, 0, buffer.Length)) > 0)
                {
                    wc.Write(buffer, 0, read);
                }
                ms.Close();

                _curriculumVitaesForProcess.Send(curriculumVitae);

                wc.Flush();
                wc.Close();

                if (curriculumVitae.NomeProfessor == null || curriculumVitae.NomeProfessor.Trim().Length == 0)
                {
                    Logger.Info(String.Format("Curriculo {0} baixado", curriculumVitae.NumeroCurriculo));
                    return;
                }

                Logger.Info(String.Format("Curriculo {0} - {1} baixado", curriculumVitae.NumeroCurriculo, curriculumVitae.NomeProfessor));
            }
            catch (Exception exception)
            {
                Logger.Error(String.Format(
                    "Erro ao buscar o currículo {0}, mensagem: {1}\n{2}",
                    curriculumVitae.NumeroCurriculo,
                    exception.Message,
                    exception.StackTrace
                ));
                _lattesModule.DecrementProcessCount();
            }
            finally
            {
                _lattesModule.TickDownloadBar();
            }
        }
    }
}
