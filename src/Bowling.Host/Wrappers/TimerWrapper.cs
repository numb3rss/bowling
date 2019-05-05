using System.Diagnostics.CodeAnalysis;
using System.Timers;

namespace Bowling.Host.Wrappers
{
    [ExcludeFromCodeCoverage]
    public class TimerWrapper : ITimer
    {
        private readonly Timer _timer = new Timer();

        public void Start(double interval)
        {
            _timer.Interval = interval;
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public event ElapsedEventHandler Elapsed
        {
            add => this._timer.Elapsed += value;
            remove => this._timer.Elapsed -= value;
        }
    }
}
