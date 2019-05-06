using Bowling.Domain.Entities;
using Xunit;

namespace Bowling.Domain.UnitTests.Entities
{
    public class ScoreTests
    {
        [Fact]
        public void Score_ReturnInstance_WithParameter()
        {
            //Arrange
            var value = 1;

            //Act
            var score = new Score(value);

            //Assert
            Assert.Equal(value, score.Value);
        }
    }
}
