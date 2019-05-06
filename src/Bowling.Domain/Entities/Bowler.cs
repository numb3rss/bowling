using System.Collections.Generic;
using System.Linq;
using Bowling.Domain.ValueObjects;

namespace Bowling.Domain.Entities
{
    public class Bowler
    {
        private const char Separator = ' ';

        public Bowler(string playerScore)
        {
            var separateFrame = playerScore.Split(Separator).ToList();
            var frames = new List<Frame>();

            var frameIndex = 0;
            foreach (var frame in separateFrame)
            {
                var rolls = frame.Select(f => new Roll(f, frameIndex)).ToList();
                frames.Add(new Frame(rolls));
                frameIndex++;
            }

            Frames = frames.AsReadOnly();
        }

        public IReadOnlyList<Frame> Frames { get; set; }
    }
}
