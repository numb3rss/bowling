using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Infrastructure.Wrappers
{
    public interface IStreamWriter : IDisposable
    {
        void WriteLine(string line);
    }
}
