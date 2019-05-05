using System;

namespace Bowling.Host.Wrappers
{
    public interface IConsole
    {
        void WriteLine(string value);
        string ReadLine();
    }
}
