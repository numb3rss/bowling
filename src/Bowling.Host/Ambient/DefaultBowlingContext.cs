using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Bowling.Host.Wrappers;

namespace Bowling.Host.Ambient
{
    internal class DefaultBowlingContext : BowlingContext
    {
        private static readonly DefaultBowlingContext InternalInstance =
            new DefaultBowlingContext();

        private DefaultBowlingContext()
        {
            EventWaitHandle = new EventWaitHandleWrapper(false, EventResetMode.AutoReset,
                Guid.NewGuid().ToString());
        }

        public override IEventWaitHandle EventWaitHandle { get; internal set; }

        public static DefaultBowlingContext Instance => DefaultBowlingContext.InternalInstance;
    }
}
