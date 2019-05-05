using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace Bowling.Host.Wrappers
{
    [ExcludeFromCodeCoverage]
    public class EventWaitHandleWrapper : IEventWaitHandle
    {
        private readonly EventWaitHandle _eventWaitHandle;

        public EventWaitHandleWrapper(bool initialState, EventResetMode mode, string name)
        {
            _eventWaitHandle = new EventWaitHandle(initialState, mode,
                name);
        }

        public bool Set()
        {
            return _eventWaitHandle.Set();
        }

       public bool WaitOne(TimeSpan timeout)
        {
            return _eventWaitHandle.WaitOne(timeout);
        }
    }
}
