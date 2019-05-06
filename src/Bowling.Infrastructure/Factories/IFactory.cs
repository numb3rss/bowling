namespace Bowling.Infrastructure.Factories
{
    public interface IFactory<in TIn, out TOut>
    {
        TOut Get(TIn input);
    }
}
