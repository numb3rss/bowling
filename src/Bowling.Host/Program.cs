using System;
using System.Diagnostics.CodeAnalysis;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Bowling.Application;
using Bowling.Application.UseCases;
using Bowling.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Bowling.Host.Ambient;
using Bowling.Host.Timers;
using Bowling.Host.Wrappers;

namespace Bowling.Host
{
    [ExcludeFromCodeCoverage]

    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();

            using(var scope = _serviceProvider.CreateScope())
            {
                var eventWaitHandle = BowlingContext.Current.EventWaitHandle;

                var console = scope.ServiceProvider.GetService<IConsole>();
                var timer = scope.ServiceProvider.GetService<ITimer>();
                var getBowlerScoreUseCase = scope.ServiceProvider.GetService<IRequestHandler<string, Score>>();

                var bowlingGameTimer = new BowlingGameTimer(2000, timer, console, getBowlerScoreUseCase);

                bool signaled;
                do
                {
                    signaled = eventWaitHandle.WaitOne(TimeSpan.FromSeconds(5));
                } while (!signaled);
            }
            
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new BowlingHostModule());
            builder.RegisterModule(new ApplicationModule());

            builder.Populate(new ServiceCollection());
            var appContainer = builder.Build();
            _serviceProvider = new AutofacServiceProvider(appContainer);
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
