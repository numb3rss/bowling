using System;
using System.Diagnostics.CodeAnalysis;
using Bowling.Domain;
using Bowling.Host.Ambient;
using Bowling.Host.Handler;
using Bowling.Host.Wrappers;
using Bowling.Infrastructure;
using Moq;
using Xunit;

namespace Bowling.Host.UnitTests.Handler
{
    [ExcludeFromCodeCoverage]
    public class GlobalExceptionHandlerTests : IDisposable
    {
        public GlobalExceptionHandlerTests()
        {
            _eventWaitHandle = new Mock<IEventWaitHandle>();
            _currentDomain = new Mock<ICurrentDomain>();
            _console = new Mock<IConsole>();

            BowlingContext.Current.EventWaitHandle = _eventWaitHandle.Object;
            var globalExceptionHandler = new GlobalExceptionHandler(_currentDomain.Object, _console.Object);
            globalExceptionHandler.Register();
        }

        public void Dispose()
        {
            BowlingContext.ResetToDefault();
        }

        private readonly Mock<ICurrentDomain> _currentDomain;
        private readonly Mock<IConsole> _console;
        private readonly Mock<IEventWaitHandle> _eventWaitHandle;

        [Fact]
        public void
            UnhandledExceptionTrapper_ShouldConsoleReadLine_WhenExceptionOccured()
        {
            //Arrange
            var exception = new Exception("It is exception");

            //Act
            _currentDomain.Raise(t => t.UnhandledException += null, new UnhandledExceptionEventArgs(exception, false));

            //Assert
            _console.Verify(c => c.ReadLine(), Times.Once);
        }

        [Fact]
        public void
            UnhandledExceptionTrapper_ShouldConsoleWriteApplicationMessage_WhenApplicationExceptionOccured()
        {
            //Arrange
            var applicationException = new ApplicationException("It is application exception");

            //Act
            _currentDomain.Raise(t => t.UnhandledException += null,
                new UnhandledExceptionEventArgs(applicationException, false));

            //Assert
            _console.Verify(c => c.WriteLine($"Application : {applicationException.Message}"), Times.Once);
        }

        [Fact]
        public void
            UnhandledExceptionTrapper_ShouldConsoleWriteDomainMessage_WhenInfrastructureExceptionOccured()
        {
            //Arrange
            var domainException = new DomainException("It is domain exception");

            //Act
            _currentDomain.Raise(t => t.UnhandledException += null,
                new UnhandledExceptionEventArgs(domainException, false));

            //Assert
            _console.Verify(c => c.WriteLine($"Domain : {domainException.Message}"), Times.Once);
        }

        [Fact]
        public void
            UnhandledExceptionTrapper_ShouldConsoleWriteHostMessage_WhenHostExceptionOccured()
        {
            //Arrange
            var hostException = new HostException("It is host exception");

            //Act
            _currentDomain.Raise(t => t.UnhandledException += null,
                new UnhandledExceptionEventArgs(hostException, false));

            //Assert
            _console.Verify(c => c.WriteLine($"Host : {hostException.Message}"), Times.Once);
        }

        [Fact]
        public void
            UnhandledExceptionTrapper_ShouldConsoleWriteInfrastructureMessage_WhenInfrastructureExceptionOccured()
        {
            //Arrange
            var infrastructureException = new InfrastructureException("It is infrastructure exception");

            //Act
            _currentDomain.Raise(t => t.UnhandledException += null,
                new UnhandledExceptionEventArgs(infrastructureException, false));

            //Assert
            _console.Verify(c => c.WriteLine($"Infrastructure : {infrastructureException.Message}"), Times.Once);
        }

        [Fact]
        public void
            UnhandledExceptionTrapper_ShouldSetEventWaitHandle_WhenExceptionOccured()
        {
            //Arrange
            var exception = new Exception("It is exception");

            //Act
            _currentDomain.Raise(t => t.UnhandledException += null,
                new UnhandledExceptionEventArgs(exception, false));

            //Assert
            _eventWaitHandle.Verify(e => e.Set(), Times.Once);
        }
    }
}