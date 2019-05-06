using Autofac;
using Bowling.Host.Handler;
using Bowling.Host.Wrappers;

namespace Bowling.Host
{
    internal class HostModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TimerWrapper>().As<ITimer>();
            builder.RegisterType<EventWaitHandleWrapper>().As<IEventWaitHandle>();
            builder.RegisterType<ConsoleWrapper>().As<IConsole>();
            builder.RegisterType<GlobalExceptionHandler>().As<IGlobalExceptionHandler>();
            builder.RegisterType<CurrentDomainWrapper>().As<ICurrentDomain>();
        }
    }
}
