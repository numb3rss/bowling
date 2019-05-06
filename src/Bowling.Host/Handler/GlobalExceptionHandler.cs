using System;
using Bowling.Domain;
using Bowling.Host.Ambient;
using Bowling.Host.Wrappers;
using Bowling.Infrastructure;

namespace Bowling.Host.Handler
{
    public class GlobalExceptionHandler : IGlobalExceptionHandler
    {
        private readonly ICurrentDomain _currentDomain;
        private readonly IConsole _console;

        public GlobalExceptionHandler(ICurrentDomain currentDomain, IConsole console)
        {
            _currentDomain = currentDomain;
            _console = console;
        }

        public void Register()
        {
            _currentDomain.UnhandledException += UnhandledExceptionTrapper;
        }

        private void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is InfrastructureException infrastructureException)
            {
                _console.WriteLine($"Infrastructure : {infrastructureException.Message}");
            }
            else if (e.ExceptionObject is DomainException domainException)
            {
                _console.WriteLine($"Domain : {domainException.Message}");
            }
            else if (e.ExceptionObject is ApplicationException applicationException)
            {
                _console.WriteLine($"Application : {applicationException.Message}");
            }
            else if (e.ExceptionObject is HostException hostException)
            {
                _console.WriteLine($"Host : {hostException.Message}");
            }

            _console.ReadLine();
            BowlingContext.Current.EventWaitHandle.Set();
        }
    }
}
