using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using LattesExtractor.Entities.Database;
using LattesExtractor.Entities;
using System.Threading;
using LattesExtractor.Entities.Xml;
using LattesExtractor.DAO;
using log4net;
using LattesExtractor.Collections;

namespace LattesExtractor.Controller
{
    class CurriculumVitaeProcessorController
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(CurriculumVitaeProcessorController).Name);

        private LattesModule _lattesModule;
        private Channel<CurriculoEntry> _curriculumVitaeForProcess;
        private int _workItemCount = 0;
        private XmlSerializer _curriculumVitaeUnserializer = new XmlSerializer(typeof(CurriculoVitaeXml));


        public CurriculumVitaeProcessorController(
            LattesModule lattesModule,
            Channel<CurriculoEntry> curriculumVitaeForProcess
        )
        {
            _lattesModule = lattesModule;
            _curriculumVitaeForProcess = curriculumVitaeForProcess;
        }

        public void ProcessCurriculumVitaes(ManualResetEvent doneEvent)
        {
            try
            {
                var processDoneEvent = new ManualResetEvent(false);
                foreach (var curriculoEntry in _curriculumVitaeForProcess.Range())
                {
                    Interlocked.Increment(ref _workItemCount);
                    ThreadPool.QueueUserWorkItem(o => ProcessCurriculumVitae(curriculoEntry, processDoneEvent));
                }
                if (_workItemCount > 0)
                {
                    processDoneEvent.WaitOne();
                }
            }
            finally
            {
                doneEvent.Set();
            }
        }

        private void ProcessCurriculumVitae(CurriculoEntry curriculoEntry, ManualResetEvent doneEvent)
        {
            try
            {
                var filename = _lattesModule.GetCurriculumVitaeFileName(curriculoEntry.NumeroCurriculo);

                var curriculumVitaeXml = new XmlDocument();
                curriculumVitaeXml.Load(filename);

                // nescessário para o deserialize reconhecer o Xml
                curriculumVitaeXml.DocumentElement.SetAttribute("xmlns", "http://tempuri.org/LMPLCurriculo");

                var curriculumVitaeXDocument = XDocument.Parse(curriculumVitaeXml.InnerXml);
                var curriculumVitae = _curriculumVitaeUnserializer.Deserialize(curriculumVitaeXDocument.CreateReader()) as CurriculoVitaeXml;
                curriculoEntry.NomeProfessor = curriculumVitae.DADOSGERAIS.NOMECOMPLETO;

                var professorDAOService = new ProfessorDAOService(new LattesDatabase());
                Logger.Debug($"Iniciando processamento currículo {curriculoEntry.NumeroCurriculo} do Professor {curriculumVitae.DADOSGERAIS.NOMECOMPLETO}...");

                if (professorDAOService.ProcessCurriculumVitaeXML(curriculumVitae, curriculoEntry))
                {
                    Logger.Info($"Currículo {curriculoEntry.NumeroCurriculo} do Professor {curriculumVitae.DADOSGERAIS.NOMECOMPLETO} processado com sucesso !");
                    File.Delete(filename);
                }

            }
            catch (Exception ex)
            {
                Logger.Error($"Erro durante a leitura do XML {curriculoEntry.NumeroCurriculo}: {ex.Message}\n{ex.StackTrace}");

                int sequencia = 1;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Logger.Error($"Excessão Interna [{sequencia++}]: {ex.Message}\n{ex.StackTrace}");
                }
            }
            finally
            {
                if (Interlocked.Decrement(ref _workItemCount) == 0)
                {
                    doneEvent.Set();
                }
            }
        }
    }
}