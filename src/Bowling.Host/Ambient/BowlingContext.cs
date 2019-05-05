using System;
using System.Collections.Generic;
using System.Text;
using Bowling.Host.Wrappers;

namespace Bowling.Host.Ambient
{
    internal abstract class BowlingContext
    {
        private static BowlingContext _current =
            DefaultBowlingContext.Instance;

        public static BowlingContext Current
        {
            get => BowlingContext._current;
            internal set => BowlingContext._current = value ?? throw new ArgumentNullException(nameof(value));
        }

        public abstract IEventWaitHandle EventWaitHandle { get; internal set; }

        public static void ResetToDefault()
        {
            BowlingContext._current = DefaultBowlingContext.Instance;
        }
    }
}
