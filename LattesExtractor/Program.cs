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
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            LattesModule lm = LattesModule.GetInstance();

            lm.TempDirectory = config.AppSettings.Settings["TempDir"].Value;
            lm.LattesCurriculumVitaeODBCConnection = config.AppSettings.Settings["LattesCurriculumVitaeODBCConnection"].Value;
            lm.LattesCurriculumVitaeQuery = config.AppSettings.Settings["LattesCurriculumVitaeQuery"].Value;

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

                XmlConfigurator.Configure(new System.IO.FileInfo("LattesExtractor.log4net"));
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
            [Option('q', "importqualis", Required = false, HelpText = "Planilha CSV com a base Qualis a ser importada")]
            public string InputQualisFile { get; set; }

            [Option('j', "importjcr", Required = false, HelpText = "Planilha CSV com a base JCR Impact Factor a ser importada")]
            public string InputJCRFile { get; set; }

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
