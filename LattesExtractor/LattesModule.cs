using System;
using System.Collections.Generic;
using LattesExtractor.Controller;
using log4net;
using LattesExtractor.Entities;
using System.IO;
using LattesExtractor.Collections;
using System.Threading;
using LattesExtractor.Entities.Database;

namespace LattesExtractor
{
    class LattesModule
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(LattesModule).Name);

        protected CurriculoLattesWebService.WSCurriculoClient wscc;

        private static readonly object locker = new object();

        private Channel<CurriculoEntry> _cvForDownload = new Channel<CurriculoEntry>();
        private Channel<CurriculoEntry> _cvForProcess = new Channel<CurriculoEntry>();

        public Channel<CurriculoEntry> CurriculumVitaeForDownload { get { return this._cvForDownload; } }
        public Channel<CurriculoEntry> CurriculumVitaeForProcess { get { return this._cvForProcess; } }

        private String _tempDir = "";
        private String _qualisFile = "";
        private String _jcrFile = "";
        private string _lattesCurriculumValueQuery = null;
        private string _lattesCurriculumValueConnection = null;
        private string _importFolder = null;
        private string _csvCurriculumValueNumberList = null;
        private List<ManualResetEvent> _doneEventsGetCurriculumVitae = new List<ManualResetEvent>();
        private List<ManualResetEvent> _doneEventsListCurriculumVitae = new List<ManualResetEvent>();
        private List<ManualResetEvent> _doneEventsProcessCurriculumVitae = new List<ManualResetEvent>();

        private static LattesModule _instance;

        public static LattesModule GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LattesModule();
            }

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
        public bool ShowProgressBar { get; internal set; }

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
                    this._csvCurriculumValueNumberList = this._csvCurriculumValueNumberList
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

        private void QueueThreadListCurriculumVitae(Action<ManualResetEvent> workItem)
        {
            var doneEvent = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem((object threadContext) => workItem(doneEvent));
            _doneEventsListCurriculumVitae.Add(doneEvent);
        }

        private void QueueThreadGetCurriculumVitae(Action<ManualResetEvent> workItem)
        {
            var doneEvent = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem((object threadContext) => workItem(doneEvent));
            _doneEventsGetCurriculumVitae.Add(doneEvent);
        }

        private void QueueThreadProcessCurriculumVitae(Action<ManualResetEvent> workItem)
        {
            var doneEvent = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem((object threadContext) => workItem(doneEvent));
            _doneEventsProcessCurriculumVitae.Add(doneEvent);
        }

        private void LoadCurriculums()
        {
            if (IgnorePendingLastExecution == false)
            {
                var loadFromTempDirectory = new LoadFromTempDirectory(this, TempDirectory, CurriculumVitaeForProcess);
                if (loadFromTempDirectory.HasPendingResumes())
                {
                    Logger.Info($"Foram encontrados XMLs pendentes na pasta '{TempDirectory}' !'");
                    QueueThreadGetCurriculumVitae(loadFromTempDirectory.LoadCurriculums);
                    return;
                }
            }

            if (ImportFolder != null)
            {
                Logger.Info($"Lendo Currículos do diretório '{ImportFolder}'...");
                var importFromFolder = new ImportCurriculumVitaeFromFolderController(
                    this,
                    ImportFolder, 
                    CurriculumVitaeForProcess
                );
                QueueThreadGetCurriculumVitae(importFromFolder.LoadCurriculums);
                return;
            }

            Logger.Info("Iniciando Carga dos Números de Currículo da Instituição...");
            if (CSVCurriculumVitaeNumberList != null)
            {
                var csvListController = new LoadCurriculumVitaeNumberFromCSVController(
                    this,
                    CSVCurriculumVitaeNumberList, 
                    CurriculumVitaeForDownload
                );
                QueueThreadListCurriculumVitae(csvListController.LoadCurriculumVitaeNumbers);
            }

            if (CSVCurriculumVitaeNumberList == null)
            {
                var oleDbController = new LoadCurriculumVitaeNumberFromOleDbController(
                    this,
                    LattesCurriculumVitaeODBCConnection,
                    LattesCurriculumVitaeQuery,
                    CurriculumVitaeForDownload
                );
                QueueThreadListCurriculumVitae(oleDbController.LoadCurriculumVitaeNumbers);
            }

            if (UseNewCNPqRestService)
            {
                Logger.Info("Iniciando Download dos Currículos Atualizados (REST Service)...");
                var downloadRestService = new DownloadFromRestServiceCurriculumVitaeController(
                    this,
                    new LattesDatabase(),
                    CurriculumVitaeForDownload,
                    CurriculumVitaeForProcess
                );
                QueueThreadGetCurriculumVitae(downloadRestService.DownloadUpdatedCurriculums);
                return;
            }

            Logger.Info("Iniciando Download dos Currículos Atualizados (WebService)...");
            var downloadWebService = new DownloadFromWebServiceCurriculumVitaeController(
                this,
                new Service.DownloadCurriculumVitaeWebService(
                    new LattesDatabase(),
                    WSCurriculoClient
                ),
                CurriculumVitaeForDownload,
                CurriculumVitaeForProcess
            );
            QueueThreadGetCurriculumVitae(downloadWebService.DownloadUpdatedCurriculums);
        }

        public void Extract()
        {
            try
            {
                if (UseNewCNPqRestService)
                {
                    Logger.Error("A opção de utilizar o serviço \"buscacv\" do CNPq esta temporáriamente indisponível até se tornar estável");
                }

                Logger.Info("Começando Processamento...");

                var processor = new CurriculumVitaeProcessorController(this, CurriculumVitaeForProcess);
                QueueThreadProcessCurriculumVitae(processor.ProcessCurriculumVitaes);

                LoadCurriculums();

                Logger.Info("Iniciando Processamento dos Currículos...");

                if (_doneEventsListCurriculumVitae.Count > 0)
                {
                    WaitHandle.WaitAll(_doneEventsListCurriculumVitae.ToArray());
                    Logger.Info("Todos os Currículos Foram Listados...");
                }
                CurriculumVitaeForDownload.Close();

                WaitHandle.WaitAll(_doneEventsGetCurriculumVitae.ToArray());
                Logger.Info("Todos os Currículos Foram Adicionados para Processamento...");
                CurriculumVitaeForProcess.Close();

                WaitHandle.WaitAll(_doneEventsProcessCurriculumVitae.ToArray());
                Logger.Info("Todos os Currículos Foram Processados...");
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }

            Logger.Info("Encerrando Execução...");
        }

        private void ShowException(Exception ex)
        {
            Logger.Error($"Erros durante a execução: {ex.Message}\n{ex.StackTrace}");
            if (ex.InnerException != null)
            {
                int sequencia = 1;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Logger.Error($"Excessão Interna [{sequencia++}]: {ex.Message}\n{ex.StackTrace}");
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
            return $"{this.TempDirectory}{Path.DirectorySeparatorChar}{curriculumVitaeNumber}.xml";
        }
    }
}
