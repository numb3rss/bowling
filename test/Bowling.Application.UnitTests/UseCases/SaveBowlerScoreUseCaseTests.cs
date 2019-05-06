using System.Diagnostics.CodeAnalysis;
using Bowling.Application.Services;
using Bowling.Application.UseCases;
using Bowling.Domain.Entities;
using Moq;
using Xunit;

namespace Bowling.Application.UnitTests.UseCases
{
    [ExcludeFromCodeCoverage]
    public class SaveBowlerScoreUseCaseTests
    {
        private readonly Mock<IFileService> _fileService;
        private readonly SaveBowlerScoreUseCase _saveBowlerScoreScoreUseCase;

        public SaveBowlerScoreUseCaseTests()
        {
            _fileService = new Mock<IFileService>();

            _saveBowlerScoreScoreUseCase = new SaveBowlerScoreUseCase(_fileService.Object);
        }

        [Fact]
        public void Handle_ShouldCallWrite_WithScore()
        {
            //Arrange
            var score = new Score(300);

            //Act
            var isSuccess = _saveBowlerScoreScoreUseCase.Handle(score);

            //Assert
            _fileService.Verify(f => f.Write(score.Value), Times.Once);
            Assert.True(isSuccess);
        }
    }
}
