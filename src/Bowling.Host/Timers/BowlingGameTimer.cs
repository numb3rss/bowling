using System.Threading;
using System.Timers;
using Bowling.Host.Ambient;
using Bowling.Host.Wrappers;

namespace Bowling.Host.Timers
{
    public class BowlingGameTimer
    {
        private readonly IConsole _console;
        private readonly ITimer _timer;
        private readonly IEventWaitHandle _eventWaitHandle;
        private readonly object _lock;

        public BowlingGameTimer(int interval, ITimer timer, IConsole console)
        {
            _timer = timer;
            _console = console;

            _timer.Start(interval);
            _timer.Elapsed += TimerOnElapsed;
            _eventWaitHandle = BowlingContext.Current.EventWaitHandle;
            _lock = new object();
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            if (Monitor.TryEnter(_lock))
            {
                _console.WriteLine("It is a bowling game. Do your choice please.");
                _console.WriteLine("To send score player, press 's'");
                _console.WriteLine("To quit application, press 'q'");

                var line = _console.ReadLine();

                if (line == null)
                {
                    return;
                }

                if (line.ToUpper() == "Q")
                {
                    _eventWaitHandle.Set();
                    _timer.Stop();
                }
                else if (line.ToUpper() == "S")
                {
                    _console.WriteLine("Please enter score.");
                }

                Monitor.Exit(_lock);
            }
        }
    }
}
