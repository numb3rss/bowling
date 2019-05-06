using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Host.Wrappers
{
    public interface ICurrentDomain
    {
        event UnhandledExceptionEventHandler UnhandledException;
    }
}
