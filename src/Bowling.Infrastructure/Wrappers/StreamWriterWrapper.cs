using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Bowling.Infrastructure.Wrappers
{
    [ExcludeFromCodeCoverage]
    internal class StreamWriterWrapper : IStreamWriter
    {
        private readonly StreamWriter _streamWriter;

        public StreamWriterWrapper(string path)
        {
            _streamWriter = new StreamWriter(path, true);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _streamWriter.Close();
                _streamWriter.Dispose();
            }
        }

        public void WriteLine(string line)
        {
            _streamWriter.WriteLine(line);
        }
    }
}
