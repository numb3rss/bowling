using System;

namespace Bowling.Host.Wrappers
{
    public interface IEventWaitHandle
    {
        bool Set();
        bool WaitOne(TimeSpan timeout);
    }
}
