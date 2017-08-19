using LattesExtractor.Entities.Database;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LattesExtractor.Controller
{
    class DownloadFromRestServiceCurriculumVitaeController
    {
        private LattesModule lattesModule;
        private LattesDatabase db;
        private int _sequence;

        private static readonly ILog Logger = LogManager.GetLogger(typeof(DownloadFromRestServiceCurriculumVitaeController).Name);

        internal static void DownloadUpdatedCurriculums(LattesModule lattesModule)
        {
            throw new NotImplementedException();
        }
    }
}
