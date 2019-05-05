using System.Timers;

namespace Bowling.Host.Wrappers
{
    public interface ITimer
    {
        void Start(double interval);
        void Stop();

        event ElapsedEventHandler Elapsed;
    }
}
