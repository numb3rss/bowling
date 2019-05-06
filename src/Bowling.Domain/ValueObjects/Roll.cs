using System;
using System.Collections.Generic;

namespace Bowling.Domain.ValueObjects
{
    public class Roll : ValueObject
    {
        public Roll(char value, int indexFrame)
        {
            Value = value;
            IndexFrame = indexFrame;
        }

        public char Value { get; }
        public int IndexFrame { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator int(Roll roll)
        {
            if (roll.Value == '-')
            {
                return 0;
            }

            if (roll.Value == 'X' || roll.Value == '/')
            {
                return 10;
            }

            return (int) char.GetNumericValue(roll.Value);
        }
    }
}
