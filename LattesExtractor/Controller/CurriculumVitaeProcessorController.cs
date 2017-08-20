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
                if(_workItemCount > 0)
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
                XmlSerializer curriculumVitaeUnserializer = new XmlSerializer(typeof(CurriculoVitaeXml));

                XmlDocument curriculumVitaeXml;
                XDocument curriculumVitaeXDocument;
                CurriculoVitaeXml curriculumVitae;

                var filename = _lattesModule.GetCurriculumVitaeFileName(curriculoEntry.NumeroCurriculo);
                //curriculumXMLFile = new FileStream(filename, FileMode.Open);

                curriculumVitaeXml = new XmlDocument();
                //curriculumVitaeXml.Load(curriculumXMLFile);
                curriculumVitaeXml.Load(filename);

                // nescessário para ie deserialize reconhecer ie Xml
                curriculumVitaeXml.DocumentElement.SetAttribute("xmlns", "http://tempuri.org/LMPLCurriculo");

                curriculumVitaeXDocument = XDocument.Parse(curriculumVitaeXml.InnerXml);

                try
                {
                    curriculumVitae = (CurriculoVitaeXml)curriculumVitaeUnserializer.Deserialize(curriculumVitaeXDocument.CreateReader());
                }
                catch (Exception ex)
                {
                    Logger.Error(String.Format("Erro durante a leitura do XML:", ex.Message));
                    Logger.Error(ex.StackTrace);
                    if (ex.InnerException != null)
                    {
                        Logger.Error("Excessão Interna:");
                        int sequencia = 1;
                        while (ex.InnerException != null)
                        {
                            ex = ex.InnerException;
                            Logger.Error(String.Format("Excessão Interna [{0}]: {1}", sequencia++, ex.Message));
                            Logger.Error(ex.StackTrace);
                        }
                    }
                    return;
                }

                var professorDAOService = new ProfessorDAOService(new LattesDatabase());
                // processa curriculo
                if (professorDAOService.ProcessCurriculumVitaeXML(curriculumVitae, curriculoEntry))
                {
                    Logger.Info(String.Format("Currículo {0} do Professor {1} processado com sucesso !", curriculoEntry.NumeroCurriculo, curriculumVitae.DADOSGERAIS.NOMECOMPLETO));
                    File.Delete(filename);
                }
            }
            finally
            {
                _lattesModule.TickProcessBar();
                if (Interlocked.Decrement(ref _workItemCount) == 0)
                {
                    doneEvent.Set();
                }
            }
        }
    }
}