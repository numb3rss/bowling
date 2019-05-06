using System.Collections.Generic;
using Bowling.Application.Services;
using Bowling.Domain.ValueObjects;
using Xunit;

namespace Bowling.Application.UnitTests.Services
{
    public class CalculateScoreServiceTests
    {
        private readonly CalculateScoreService _calculateScoreService;

        public CalculateScoreServiceTests()
        {
            _calculateScoreService = new CalculateScoreService();
        }

        [Fact]
        public void Get_ReturnScore_WithRollsCase1()
        {
            //Arrange
            var frames = new List<Frame>
            {
                new Frame(new List<Roll>{new Roll('X', 1)}),
                new Frame(new List<Roll>{new Roll('X', 2)}),
                new Frame(new List<Roll>{new Roll('X', 3)}),
                new Frame(new List<Roll>{new Roll('X', 4)}),
                new Frame(new List<Roll>{new Roll('X', 5)}),
                new Frame(new List<Roll>{new Roll('X', 6)}),
                new Frame(new List<Roll>{new Roll('X', 7)}),
                new Frame(new List<Roll>{new Roll('X', 8)}),
                new Frame(new List<Roll>{new Roll('X', 9)}),
                new Frame(new List<Roll>{new Roll('X', 10), new Roll('X', 10), new Roll('X', 10)})
            };

            //Act
            var score = _calculateScoreService.Get(frames);

            //Assert
            Assert.Equal(300, score);
        }

        [Fact]
        public void Get_ReturnScore_WithRollsCase2()
        {
            //Arrange
            var frames = new List<Frame>
            {
                new Frame(new List<Roll>{ new Roll('9', 1), new Roll('-', 1) }),
                new Frame(new List<Roll>{ new Roll('9', 2), new Roll('-', 2) }),
                new Frame(new List<Roll>{ new Roll('9', 3), new Roll('-', 3) }),
                new Frame(new List<Roll>{ new Roll('9', 4), new Roll('-', 4) }),
                new Frame(new List<Roll>{ new Roll('9', 5), new Roll('-', 5) }),
                new Frame(new List<Roll>{ new Roll('9', 6), new Roll('-', 6) }),
                new Frame(new List<Roll>{ new Roll('9', 7), new Roll('-', 7) }),
                new Frame(new List<Roll>{ new Roll('9', 8), new Roll('-', 8) }),
                new Frame(new List<Roll>{ new Roll('9', 9), new Roll('-', 9) }),
                new Frame(new List<Roll>{ new Roll('9', 10), new Roll('-', 10) })
            };

            //Act
            var score = _calculateScoreService.Get(frames);

            //Assert
            Assert.Equal(90, score);
        }
    }
}
