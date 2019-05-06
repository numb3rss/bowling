namespace Bowling.Domain.Entities
{
    public class Score
    {
        public Score(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}
