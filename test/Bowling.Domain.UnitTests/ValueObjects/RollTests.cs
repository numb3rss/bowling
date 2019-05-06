using Bowling.Domain.ValueObjects;
using Xunit;

namespace Bowling.Domain.UnitTests.ValueObjects
{
    public class RollTests
    {
        [Fact]
        public void Roll_ReturnInstance_WhenConstructed()
        {
            //Arrange
            var indexFrame = 1;
            char value = 'c';

            //Act
            var roll = new Roll(value, indexFrame);

            //Assert
            Assert.Equal(value, roll.Value);
            Assert.Equal(indexFrame, roll.IndexFrame);
        }

        [Fact]
        public void ImplicitOperator_ReturnInt_WhenConvertFailRoll()
        {
            //Arrange
            var indexFrame = 1;
            var score = 0;
            var roll = new Roll('-', indexFrame);

            //Act
            int conversion = roll;

            //Assert
            Assert.Equal(score, conversion);
        }

        [Fact]
        public void ImplicitOperator_ReturnInt_WhenConvertStrikeRoll()
        {
            //Arrange
            var indexFrame = 1;
            var score = 10;
            var roll = new Roll('X', indexFrame);

            //Act
            int conversion = roll;

            //Assert
            Assert.Equal(score, conversion);
        }

        [Fact]
        public void ImplicitOperator_ReturnInt_WhenConvertSpareRoll()
        {
            //Arrange
            var indexFrame = 1;
            var score = 10;
            var roll = new Roll('/', indexFrame);

            //Act
            int conversion = roll;

            //Assert
            Assert.Equal(score, conversion);
        }

        [Fact]
        public void ImplicitOperator_ReturnInt_WhenConvertOtherRoll()
        {
            //Arrange
            var indexFrame = 1;
            var score = 9;
            var roll = new Roll('9', indexFrame);

            //Act
            int conversion = roll;

            //Assert
            Assert.Equal(score, conversion);
        }
    }
}
