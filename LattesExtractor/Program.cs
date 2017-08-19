using CommandLine;
using CommandLine.Text;
using log4net.Config;
using System;
using System.Configuration;

namespace LattesExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlConfigurator.Configure(new System.IO.FileInfo("LattesExtractor.log4net"));
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            LattesModule lm = LattesModule.GetInstance();

            lm.TempDirectory = config.AppSettings.Settings["TempDir"].Value;

            if (config.AppSettings.Settings["LattesCurriculumVitaeODBCConnection"] != null &&
                config.AppSettings.Settings["LattesCurriculumVitaeQuery"] != null)
            {
                lm.LattesCurriculumVitaeODBCConnection = config.AppSettings.Settings["LattesCurriculumVitaeODBCConnection"].Value;
                lm.LattesCurriculumVitaeQuery = config.AppSettings.Settings["LattesCurriculumVitaeQuery"].Value;
            }

            if (config.AppSettings.Settings["IgnorePedingLastExecution"] != null)
            {
                lm.IgnorePendingLastExecution = config.AppSettings.Settings["IgnorePedingLastExecution"].Value.Equals("true");
            }

            if (config.AppSettings.Settings["ImportFolder"] != null)
            {
                lm.ImportFolder = config.AppSettings.Settings["ImportFolder"].Value;
            }

            if (config.AppSettings.Settings["UseNewCNPqRestService"] != null)
            {
                lm.UseNewCNPqRestService = config.AppSettings.Settings["UseNewCNPqRestService"].Value.Equals("true") ||
                    config.AppSettings.Settings["UseNewCNPqRestService"].Value.Equals("1");
            }

            if (config.AppSettings.Settings["CSVCurriculumVitaeNumber"] != null)
            {
                lm.CSVCurriculumVitaeNumberList = config.AppSettings.Settings["CSVCurriculumValueNumberList"].Value;
            }

            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                if (options.InputQualisFile != null && options.InputQualisFile != "")
                {
                    // Values are available here
                    if (options.Verbose)
                        Console.WriteLine("Arquivo Qualis: {0}", options.InputQualisFile);
                    lm.UpdateQualisDataBase(options.InputQualisFile);
                    return;
                }

                if (options.InputJCRFile != null && options.InputJCRFile != "")
                {
                    // Values are available here
                    if (options.Verbose)
                        Console.WriteLine("Arquivo JCR Impact Factor: {0}", options.InputJCRFile);
                    lm.UpdateJCRImpactFactorDataBase(options.InputJCRFile);
                    return;
                }

                if (options.IgnorePendingLastExecution)
                {
                    lm.IgnorePendingLastExecution = options.IgnorePendingLastExecution;
                }

                if (options.FromFolder != null)
                {
                    lm.ImportFolder = options.FromFolder;
                }

                if (options.UseNewRestService)
                {
                    lm.UseNewCNPqRestService = options.UseNewRestService;
                }

                if (options.CSVCurriculumVitaeNumberList != null)
                {
                    lm.CSVCurriculumVitaeNumberList = options.CSVCurriculumVitaeNumberList;
                }

                lm.Extract();
            }

        }

        public static void AddValue(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Minimal);
        }

        class Options
        {
            [Option('\0', "usenewrestservice", DefaultValue = false, HelpText = "Será utilizado o serviço REST do CNPq no lugar do WebService")]
            public bool UseNewRestService { get; set; }

            [Option('\0', "cvcsvlist", Required = false, HelpText = "Arquivo CSV para importar a lista de currículos para download")]
            public string CSVCurriculumVitaeNumberList { get; set; }

            [Option('f', "fromfolder", Required = false, HelpText = "Directório contendo os arquivos XML (caso seja informado serão considerados apenas os curriculos já existentes na pasta, não será feita busca no Lattes)")]
            public string FromFolder { get; set; }

            [Option('q', "importqualis", Required = false, HelpText = "Planilha CSV com a base Qualis a ser importada")]
            public string InputQualisFile { get; set; }

            [Option('j', "importjcr", Required = false, HelpText = "Planilha CSV com a base JCR Impact Factor a ser importada")]
            public string InputJCRFile { get; set; }

            [Option('i', "ignoreLastExecution", DefaultValue = false, HelpText = "Deve ignorar curriculos pendentes de processamento da última execução")]
            public bool IgnorePendingLastExecution { get; set; }

            [Option('v', "verbose", DefaultValue = true,
              HelpText = "Imprime forma de uso.")]
            public bool Verbose { get; set; }

            [ParserState]
            public IParserState LastParserState { get; set; }

            [HelpOption]
            public string GetUsage()
            {
                return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
            }
        }
    }
}
