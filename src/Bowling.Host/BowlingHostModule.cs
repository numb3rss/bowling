using Autofac;
using Bowling.Host.Wrappers;

namespace Bowling.Host
{
    internal class BowlingHostModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TimerWrapper>().As<ITimer>();
            builder.RegisterType<EventWaitHandleWrapper>().As<IEventWaitHandle>();
            builder.RegisterType<ConsoleWrapper>().As<IConsole>();
        }
    }
}
