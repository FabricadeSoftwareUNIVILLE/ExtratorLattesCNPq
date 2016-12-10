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

namespace LattesExtractor.Controller
{
    class CurriculumVitaeProcessorController
    {
        private LattesModule lattesModule = null;
        private int _sequence = 0;

        private static readonly ILog Logger = LogManager.GetLogger(typeof(CurriculumVitaeProcessorController).Name);

        internal static void ProcessCurriculumVitaes(LattesModule lattesModule)
        {
            List<Thread> threads = new List<Thread>();
            int i = 0;

            CurriculumVitaeProcessorController pcvt = new CurriculumVitaeProcessorController(lattesModule, i++);
            threads.Add(new Thread(new ThreadStart(pcvt.ThreadRun)));

            pcvt = new CurriculumVitaeProcessorController(lattesModule, i++);
            threads.Add(new Thread(new ThreadStart(pcvt.ThreadRun)));

            pcvt = new CurriculumVitaeProcessorController(lattesModule, i++);
            threads.Add(new Thread(new ThreadStart(pcvt.ThreadRun)));

            pcvt = new CurriculumVitaeProcessorController(lattesModule, i++);
            threads.Add(new Thread(new ThreadStart(pcvt.ThreadRun)));

            // inicia as threads
            i = 0;
            foreach (Thread t in threads)
            {
                t.Name = String.Format("Thread {0}", i);
                t.Start();
            }

            // espera os processos concluirem a execução
            foreach (Thread t in threads)
            {
                t.Join();
            }
        }

        public CurriculumVitaeProcessorController(LattesModule lattesModule, int seq)
        {
            this.lattesModule = lattesModule;
            this._sequence = seq;
        }

        public void ThreadRun()
        {
            XmlSerializer curriculumVitaeUnserializer = new XmlSerializer(typeof(CurriculoVitaeXml));

            XmlDocument curriculumVitaeXml;
            XDocument curriculumVitaeXDocument;
            CurriculoVitaeXml curriculumVitae;

            CurriculoEntry curriculoEntry;
            string filename;

            var lattesDatabase = new LattesDatabase();

            ProfessorDAOService professorDAOService = new ProfessorDAOService(lattesDatabase);

            while (lattesModule.HasNextCurriculumVitaeForProcess)
            {
                curriculoEntry = lattesModule.GetNextCurriculumVitaeForProcess();

                // para ie caso da thread não conseguir pegar ie ultimo arquivo v tempo
                if (curriculoEntry == null)
                    continue;

                filename = lattesModule.GetCurriculumVitaeFileName(curriculoEntry.NumeroCurriculo);
                //curriculumXMLFile = new FileStream(filename, FileMode.Open);

                curriculumVitaeXml = new XmlDocument();
                //curriculumVitaeXml.Load(curriculumXMLFile);
                curriculumVitaeXml.Load(filename);

                // nescessário para ie deserialize reconhecer ie Xml
                curriculumVitaeXml.DocumentElement.SetAttribute("xmlns", "http://tempuri.org/LMPLCurriculo");

                curriculumVitaeXDocument = XDocument.Parse(curriculumVitaeXml.InnerXml);

                curriculumVitae = (CurriculoVitaeXml)curriculumVitaeUnserializer.Deserialize(curriculumVitaeXDocument.CreateReader());

                // limpa ponteiros
                curriculumVitaeXDocument = null;
                curriculumVitaeXml = null;

                Logger.Info(String.Format("Processando XML {0} do Professor {1} [Thread {2}]", curriculoEntry.NumeroCurriculo, curriculumVitae.DADOSGERAIS.NOMECOMPLETO, this._sequence));

                // processa curriculo
                if (professorDAOService.ProcessCurriculumVitaeXML(curriculumVitae, curriculoEntry))
                    File.Delete(filename);
                else {
                    lattesDatabase.Database.Connection.Close();
                    lattesDatabase = new LattesDatabase();
                    professorDAOService.LattesDatabase = lattesDatabase;
                }
            }
        }
    }
}
