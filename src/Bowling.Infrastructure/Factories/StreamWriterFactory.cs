using Bowling.Infrastructure.Wrappers;

namespace Bowling.Infrastructure.Factories
{
    internal class StreamWriterFactory : IFactory<string, IStreamWriter>
    {
        public IStreamWriter Get(string input)
        {
            return new StreamWriterWrapper(input);
        }
    }
}