using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Bowling.Domain.ValueObjects;
using Xunit;

namespace Bowling.Domain.UnitTests.ValueObjects
{
    [ExcludeFromCodeCoverage]
    public class FrameTests
    {
        [Fact]
        public void Frame_ReturnInstance_WhenConstructed()
        {
            //Arrange
            var rolls = new List<Roll>
            {
                new Roll('9', 1),
                new Roll('-', 1)
            };

            //Act
            var frame = new Frame(rolls);

            //Assert
            var actualRolls = frame.Rolls;
            Assert.Equal(rolls.Count, actualRolls.Count);
            for (int i = 0; i < actualRolls.Count; i++)
            {
                Assert.Equal(rolls[i].Value, actualRolls[i].Value);
            }
        }

        [Fact]
        public void ImplicitOperator_ReturnFrameInstance_WhenPassedListRolls()
        {
            //Arrange
            var rolls = new List<Roll>
            {
                new Roll('9', 1),
                new Roll('-', 1)
            };

            //Act
            Frame frame = rolls;

            //Assert
            Assert.NotNull(frame);
            var actualRolls = frame.Rolls;
            Assert.Equal(rolls.Count, actualRolls.Count);
            for (int i = 0; i < actualRolls.Count; i++)
            {
                Assert.Equal(rolls[i].Value, actualRolls[i].Value);
            }
        }

        [Fact]
        public void IsStrike_ReturnTrue_WhenThereIsOneRollAndValueEqualX()
        {
            //Arrange
            var rolls = new List<Roll>
            {
                new Roll('X', 1)
            };

            //Act
            Frame frame = rolls;
            var isStrike = frame.IsStrike();

            //Assert
            Assert.True(isStrike);
        }

        [Fact]
        public void IsStrike_ReturnFalse_WhenThereIsManyRolls()
        {
            //Arrange
            var rolls = new List<Roll>
            {
                new Roll('9', 1),
                new Roll('-', 1)
            };

            //Act
            Frame frame = rolls;
            var isStrike = frame.IsStrike();

            //Assert
            Assert.False(isStrike);
        }

        [Fact]
        public void IsSpare_ReturnTrue_WhenThereIsTwoRollsAndSecondRollValueEqualSlash()
        {
            //Arrange
            var rolls = new List<Roll>
            {
                new Roll('2', 1),
                new Roll('/', 1)
            };

            //Act
            Frame frame = rolls;
            var isSpare = frame.IsSpare();

            //Assert
            Assert.True(isSpare);
        }

        [Fact]
        public void IsSpare_ReturnFalse_WhenThereIsTwoRollsAndSecondRollValueNotEqualSlash()
        {
            //Arrange
            var rolls = new List<Roll>
            {
                new Roll('2', 1),
                new Roll('-', 1)
            };

            //Act
            Frame frame = rolls;
            var isSpare = frame.IsSpare();

            //Assert
            Assert.False(isSpare);
        }
    }
}
