using System;
using System.Diagnostics.CodeAnalysis;
using Bowling.Infrastructure.Factories;
using Bowling.Infrastructure.FileAccess;
using Bowling.Infrastructure.Wrappers;
using Moq;
using Xunit;

namespace Bowling.Infrastructure.UnitTests.Services
{
    [ExcludeFromCodeCoverage]
    public class FileServiceTests
    {
        private readonly FileService _fileService;
        private readonly Mock<IFactory<string, IStreamWriter>> _streamWriterFactoryMock;
        private readonly Mock<IStreamWriter> _streamWriterMock;

        public FileServiceTests()
        {
            _streamWriterFactoryMock = new Mock<IFactory<string, IStreamWriter>>();
            _streamWriterMock = new Mock<IStreamWriter>();

            _streamWriterFactoryMock.Setup(s => s.Get(It.IsAny<string>())).Returns(_streamWriterMock.Object);
            _fileService = new FileService(_streamWriterFactoryMock.Object);
        }

        [Fact]
        public void Write_ShouldGetStreamWriterFactory_WithPath()
        {
            //Arrange
            var path = @"C:\score_bowler.txt";
            int score = 300;

            //Act
            _fileService.Write(score);

            //Assert
            _streamWriterFactoryMock.Verify(s => s.Get(path), Times.Once);
        }

        [Fact]
        public void Write_ShouldWriteLine_WithScore()
        {
            //Arrange
            int score = 300;
            var line = $"bowler mark {score} points.";

            //Act
            _fileService.Write(score);

            //Assert
            _streamWriterMock.Verify(s => s.WriteLine(line), Times.Once);
        }

        [Fact]
        public void Write_ThrowInfrastructureException_WhenWritingLineIntoFile()
        {
            //Arrange
            var exception = new Exception("an exception occured");
            int score = 300;
            _streamWriterMock.Setup(s => s.WriteLine(It.IsAny<string>())).Throws(exception);

            //Act
            void TestCode() => _fileService.Write(score);

            //Assert
            var exceptionActual = Assert.Throws<InfrastructureException>((Action) TestCode);
            Assert.NotNull(exceptionActual);
            Assert.Equal(exception.Message, exceptionActual.Message);
        }
    }
}
