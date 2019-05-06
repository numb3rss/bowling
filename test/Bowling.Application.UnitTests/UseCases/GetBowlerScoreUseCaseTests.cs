using System.Collections.Generic;
using Bowling.Application.Services;
using Bowling.Application.UseCases;
using Bowling.Domain.ValueObjects;
using Moq;
using Xunit;

namespace Bowling.Application.UnitTests.UseCases
{
    public class GetBowlerScoreUseCaseTests
    {
        private readonly GetBowlerScoreUseCase _getBowlerScoreUseCase;
        private readonly Mock<ICalculateScoreService> _calculateScoreService;

        public GetBowlerScoreUseCaseTests()
        {
            _calculateScoreService = new Mock<ICalculateScoreService>();

            _getBowlerScoreUseCase = new GetBowlerScoreUseCase(_calculateScoreService.Object);
        }

        [Fact]
        public void Handle_ReturnScore_WithData()
        {
            //Arrange
            var data = "X X X X X X X X X X";

            //Act
            var value = _getBowlerScoreUseCase.Handle(data);

            //Assert
            Assert.NotNull(value);
            Assert.Equal(0, value.Value);
        }

        [Fact]
        public void Handle_ShouldCallCalculateScoreService_WithFrames()
        {
            //Arrange
            var data = "X X X X X X X X X X";
            var scoreExpected = 150;
            _calculateScoreService.Setup(c => c.Get(It.IsAny<List<Frame>>())).Returns(scoreExpected);

            //Act
            var score = _getBowlerScoreUseCase.Handle(data);

            //Assert
            _calculateScoreService.Verify(c => c.Get(It.IsAny<List<Frame>>()), Times.Once);
            Assert.Equal(scoreExpected, score.Value);
        }
    }
}
