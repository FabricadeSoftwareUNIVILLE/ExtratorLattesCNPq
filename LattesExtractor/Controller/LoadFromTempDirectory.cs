using System.IO;
using LattesExtractor.Entities;
using LattesExtractor.Collections;
using System.Threading;
using System.Collections.Generic;

namespace LattesExtractor.Controller
{
    class LoadFromTempDirectory
    {
        private string _tempDirectory = null;
        private Channel<CurriculoEntry> _channel = null;

        public LoadFromTempDirectory(string tempDirectory, Channel<CurriculoEntry> channel)
        {
            this._tempDirectory = tempDirectory;
            this._channel = channel;
        }

        public bool HasPendingResumes()
        {
            return Directory.GetFiles(this._tempDirectory).Length > 0;
        }

        public void LoadCurriculums(object threadContext)
        {
            var doneEvent = (ManualResetEvent)threadContext;
            try
            {
                foreach (string filename in Directory.EnumerateFiles(this._tempDirectory))
                {
                    string numeroCurriculo = filename.Substring(this._tempDirectory.Length + 1);
                    numeroCurriculo = numeroCurriculo.Substring(0, numeroCurriculo.Length - 4);
                    this._channel.Send(new CurriculoEntry { NumeroCurriculo = numeroCurriculo });
                }
            }
            finally
            {
                doneEvent.Set();
            }
        }
    }
}
