using System.Collections.Generic;
using System.Linq;

namespace Bowling.Domain.ValueObjects
{
    public class Frame : ValueObject
    {
        public Frame(IReadOnlyList<Roll> rolls)
        {
            Rolls = rolls;
        }

        public IReadOnlyList<Roll> Rolls { get; }

        public static implicit operator Frame(List<Roll> rolls)
        {
            return new Frame(rolls);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Rolls;
        }

        public bool IsStrike()
        {
            return Rolls.Count == 1 && Rolls.First().Value == 'X';
        }

        public bool IsSpare()
        {
            return Rolls.Count == 2 && Rolls[1].Value == '/';
        }
    }
}
