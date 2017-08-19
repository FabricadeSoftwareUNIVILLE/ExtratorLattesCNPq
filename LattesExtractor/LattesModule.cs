using System;
using System.Collections.Generic;
using LattesExtractor.Controller;
using log4net;
using LattesExtractor.Entities;
using System.IO;
using LattesExtractor.Collections;
using System.Threading;

namespace LattesExtractor
{
    class LattesModule
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(LattesModule).Name);

        protected CurriculoLattesWebService.WSCurriculoClient wscc;

        private static readonly object locker = new object();

        private Channel<CurriculoEntry> _cvForDownload = new Channel<CurriculoEntry>();
        private Channel<CurriculoEntry> _cvForProcess = new Channel<CurriculoEntry>();

        public Channel<CurriculoEntry> ResumesForDownload { get { return this._cvForDownload; } }
        public Channel<CurriculoEntry> ResumesForProcess { get { return this._cvForProcess; } }

        private String _tempDir = "";
        private String _qualisFile = "";
        private String _jcrFile = "";
        private string _lattesCurriculumValueQuery = null;
        private string _lattesCurriculumValueConnection = null;
        private string _importFolder = null;
        private string _csvCurriculumValueNumberList = null;
        private List<ManualResetEvent> _doneEvents = new List<ManualResetEvent>();

        private static LattesModule _instance;

        public static LattesModule GetInstance()
        {
            if (_instance == null)
                _instance = new LattesModule();

            return _instance;
        }

        private LattesModule()
        {
            this.wscc = new CurriculoLattesWebService.WSCurriculoClient();
        }

        public string ImportFolder
        {
            get { return this._importFolder; }
            set
            {
                this._importFolder = value;

                if (this._importFolder != null)
                {
                    this._importFolder = this._importFolder
                        .Replace('\\', Path.DirectorySeparatorChar)
                        .Replace('/', Path.DirectorySeparatorChar);
                }
            }
        }

        public bool IgnorePendingLastExecution { get; set; }
        public bool UseNewCNPqRestService { get; set; }

        public String TempDirectory
        {
            get { return this._tempDir; }
            set
            {
                this._tempDir = value
                    .Replace('\\', Path.DirectorySeparatorChar)
                    .Replace('/', Path.DirectorySeparatorChar);
            }
        }

        public string CSVCurriculumVitaeNumberList { get { return _csvCurriculumValueNumberList;  }
            set
            {
                this._csvCurriculumValueNumberList = value;

                if (this._csvCurriculumValueNumberList != null)
                {
                    this._importFolder = this._csvCurriculumValueNumberList
                        .Replace('\\', Path.DirectorySeparatorChar)
                        .Replace('/', Path.DirectorySeparatorChar);
                }
            }
        }

        public String QualisFileName
        {
            get { return this._qualisFile; }
            set { this._qualisFile = value; }
        }
        public string JCRFileName
        {
            get { return this._jcrFile; }
            set { this._jcrFile = value; }
        }

        public string LattesCurriculumVitaeQuery
        {
            get { return this._lattesCurriculumValueQuery; }
            set { this._lattesCurriculumValueQuery = value; }
        }

        public string LattesCurriculumVitaeODBCConnection
        {
            get { return this._lattesCurriculumValueConnection; }
            set { this._lattesCurriculumValueConnection = value; }
        }

        public CurriculoLattesWebService.WSCurriculoClient WSCurriculoClient { get { return this.wscc; } }

        private void QueueThread(WaitCallback waitCallback)
        {
            var doneEvent = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem(waitCallback, doneEvent);
            _doneEvents.Add(doneEvent);
        }

        private void LoadCurriculums()
        {
            if (this.IgnorePendingLastExecution == false)
            {
                var loadFromTempDirectory = new LoadFromTempDirectory(this.TempDirectory, this.ResumesForProcess);
                if (loadFromTempDirectory.HasPendingResumes())
                {
                    Logger.Info(String.Format("Foram encontrados XMLs pendentes na pasta '{0}' !'", this.TempDirectory));
                    this.QueueThread(loadFromTempDirectory.LoadCurriculums);
                    return;
                }
            }

            if (this.ImportFolder != null)
            {
                Logger.Info(String.Format("Lendo Currículos do diretório '{0}'...", this.ImportFolder));
                var importFromFolder = new ImportCurriculumVitaeFromFolderController(
                    this, 
                    ImportFolder, 
                    ResumesForProcess
                );
                this.QueueThread(importFromFolder.LoadCurriculums);
                return;
            }

            Logger.Info("Iniciando Carga dos Números de Currículo da Instituição...");
            if (this.CSVCurriculumVitaeNumberList != null)
            {
                var csvListController = new LoadCurriculumVitaeNumberFromCSVController(
                    CSVCurriculumVitaeNumberList, 
                    ResumesForDownload
                );
                this.QueueThread(csvListController.LoadCurriculumVitaeNumbers);
            }

            if (this.CSVCurriculumVitaeNumberList == null)
            {
                var oleDbController = new LoadCurriculumVitaeNumberFromOleDbController(
                    LattesCurriculumVitaeODBCConnection,
                    LattesCurriculumVitaeQuery,
                    ResumesForDownload
                );
                this.QueueThread(oleDbController.LoadCurriculumVitaeNumbers);
            }

            if (this.UseNewCNPqRestService)
            {
                Logger.Info("Iniciando Download dos Currículos Atualizados (REST Service)...");
                DownloadFromRestServiceCurriculumVitaeController.DownloadUpdatedCurriculums(this);
            }

            Logger.Info("Iniciando Download dos Currículos Atualizados (WebService)...");
            DownloadFromWebServiceCurriculumVitaeController.DownloadUpdatedCurriculums(this);
        }

        public void Extract()
        {
            try
            {
                Logger.Info("Começando Processamento...");

                LoadCurriculums();

                Logger.Info("Iniciando Processamento dos Currículos...");
                CurriculumVitaeProcessorController.ProcessCurriculumVitaes(this);

                WaitHandle.WaitAll(_doneEvents.ToArray());
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }

            Logger.Info("Encerrando Execução...");
        }

        private void ShowException(Exception ex)
        {
            Logger.Error("Erros durante a execução:");
            Logger.Error(ex.Message);

            Logger.Error(ex.StackTrace);
            if (ex.InnerException != null)
            {
                Logger.Error("Excessão Interna:");
                int sequencia = 1;
                while (ex.InnerException != null)
                {
                    Logger.Error(String.Format("Excessão Interna [{0}]: {1}", sequencia++, ex.InnerException.Message));
                    Logger.Error(ex.StackTrace);
                    ex = ex.InnerException;
                }
            }
        }

        public void UpdateQualisDataBase(string csvQualis)
        {
            QualisFileName = csvQualis;
            Logger.Info("Iniciando Processamento do Qualis...");
            LoadQualisTableController.LoadQualisTable(this);
        }

        public void UpdateJCRImpactFactorDataBase(string inputJCRFile)
        {
            JCRFileName = inputJCRFile;
            Logger.Info("Iniciando Processamento do JCR Impact Factor...");
            LoadJCRTableController.LoadJCRTable(this);
        }

        public string GetCurriculumVitaeFileName(string curriculumVitaeNumber)
        {
            return String.Format("{0}{1}{2}.xml", this.TempDirectory, Path.DirectorySeparatorChar, curriculumVitaeNumber);
        }
    }
}
