using Bowling.Domain.Entities;
using Xunit;

namespace Bowling.Domain.UnitTests.ValueObjects
{
    public class BowlerTests
    {
        [Fact]
        public void Bowler_ReturnInstance_WhenProvidePlayerScoreCase1()
        {
            //Arrange
            var playerScore = "X X X X X X X X X X";

            //Act
            var bowler = new Bowler(playerScore);

            //Assert
            Assert.Equal(10, bowler.Frames.Count);
            foreach (var frame in bowler.Frames)
            {
                Assert.Equal('X',frame.Rolls[0].Value);
            }
        }

        [Fact]
        public void Bowler_ReturnInstance_WhenProvidePlayerScoreCase2()
        {
            //Arrange
            var playerScore = "9- 9- 9- 9- 9- 9- 9- 9- 9- 9-";

            //Act
            var bowler = new Bowler(playerScore);

            //Assert
            Assert.Equal(10, bowler.Frames.Count);
            foreach (var frame in bowler.Frames)
            {
                Assert.Equal('9', frame.Rolls[0].Value);
                Assert.Equal('-', frame.Rolls[1].Value);
            }
        }

        [Fact]
        public void Bowler_ReturnInstance_WhenProvidePlayerScoreCase3()
        {
            //Arrange
            var playerScore = "5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5";

            //Act
            var bowler = new Bowler(playerScore);

            //Assert
            Assert.Equal(10, bowler.Frames.Count);
            for (int i = 0; i < bowler.Frames.Count - 1; i++)
            {
                Assert.Equal('5', bowler.Frames[i].Rolls[0].Value);
                Assert.Equal('/', bowler.Frames[i].Rolls[1].Value);
            }

            Assert.Equal('5', bowler.Frames[bowler.Frames.Count - 1].Rolls[0].Value);
            Assert.Equal('/', bowler.Frames[bowler.Frames.Count - 1].Rolls[1].Value);
            Assert.Equal('5', bowler.Frames[bowler.Frames.Count - 1].Rolls[2].Value);
        }
    }
}
