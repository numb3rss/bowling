using System.Diagnostics.CodeAnalysis;
using Bowling.Infrastructure.Factories;
using Bowling.Infrastructure.Wrappers;
using Xunit;

namespace Bowling.Infrastructure.UnitTests.Factories
{
    [ExcludeFromCodeCoverage]
    public class StreamWriterFactoryTests
    {
        private readonly StreamWriterFactory _streamWriterFactory;

        public StreamWriterFactoryTests()
        {
            _streamWriterFactory = new StreamWriterFactory();
        }

        [Fact]
        public void Get_ReturnStreamWriterWrapper_WithPathParameter()
        {
            //Arrange
            var path = "path";

            //Act
            var streamWriterWrapper = _streamWriterFactory.Get(path) as StreamWriterWrapper;

            //Assert
            Assert.NotNull(streamWriterWrapper);
        }
    }
}
