using System.Collections.Generic;
using System.Linq;
using Bowling.Domain.ValueObjects;

namespace Bowling.Application.Services
{
    public class CalculateScoreService : ICalculateScoreService
    {
        public int Get(List<Frame> frames)
        {
            var rolls = new List<int>();
            frames.ForEach(f =>
            {
                foreach (var roll in f.Rolls)
                {
                    rolls.Add(roll);
                }
            });

            return Scores(rolls).Take(10).Sum();
        }

        private IEnumerable<int> Scores(IList<int> rolls)
        {
            // Walk the list in steps of two rolls (= one frame)
            for (int i = 0; i + 1 < rolls.Count; i += 2)
            {
                // Neither strike nor spare
                if (rolls[i] + rolls[i + 1] < 10)
                {
                    yield return rolls[i] + rolls[i + 1];
                    continue;
                }

                // Score can only be determined if third roll is available
                if (i + 2 >= rolls.Count)
                    yield break;

                yield return rolls[i] + rolls[i + 1] + rolls[i + 2];

                // In case of strike, advance only by one
                if (rolls[i] == 10)
                    i--;
            }
        }
    }
}
