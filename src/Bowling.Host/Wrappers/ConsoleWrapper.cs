using System;
using System.Diagnostics.CodeAnalysis;

namespace Bowling.Host.Wrappers
{
    [ExcludeFromCodeCoverage]
    internal class ConsoleWrapper : IConsole
    {
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
