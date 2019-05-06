namespace Bowling.Application.UseCases
{
    public interface IRequestHandler<in TRequest, out TResponse>
    {
        TResponse Handle(TRequest data);
    }
}
