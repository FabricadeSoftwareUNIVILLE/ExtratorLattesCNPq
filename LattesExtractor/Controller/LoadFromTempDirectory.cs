using System.IO;
using LattesExtractor.Entities;
using LattesExtractor.Collections;
using System.Threading;
using System.Collections.Generic;

namespace LattesExtractor.Controller
{
    class LoadFromTempDirectory
    {
        private LattesModule _lattesModule;
        private string _tempDirectory = null;
        private Channel<CurriculoEntry> _channel = null;

        public LoadFromTempDirectory(LattesModule lattesModule, string tempDirectory, Channel<CurriculoEntry> channel)
        {
            _lattesModule = lattesModule;
            _tempDirectory = tempDirectory;
            _channel = channel;
        }

        public bool HasPendingResumes()
        {
            return Directory.GetFiles(this._tempDirectory).Length > 0;
        }

        public void LoadCurriculums(ManualResetEvent doneEvent)
        {
            try
            {
                foreach (string filename in Directory.EnumerateFiles(this._tempDirectory))
                {
                    string numeroCurriculo = filename.Substring(this._tempDirectory.Length + 1);
                    numeroCurriculo = numeroCurriculo.Substring(0, numeroCurriculo.Length - 4);
                    _channel.Send(new CurriculoEntry { NumeroCurriculo = numeroCurriculo });
                    _lattesModule.IncrementProcessCount();
                }
            }
            finally
            {
                doneEvent.Set();
            }
        }
    }
}
