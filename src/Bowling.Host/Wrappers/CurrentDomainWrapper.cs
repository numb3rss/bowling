using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Bowling.Host.Wrappers
{
    [ExcludeFromCodeCoverage]
    internal class CurrentDomainWrapper : ICurrentDomain
    {
        public event UnhandledExceptionEventHandler UnhandledException
        {
            add => AppDomain.CurrentDomain.UnhandledException += value;
            remove => AppDomain.CurrentDomain.UnhandledException -= value;
        }
    }
}
