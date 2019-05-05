using Bowling.Host.Services;
using Xunit;

namespace Bowling.Host.UnitTests.Services
{
    public class DemoServiceTests
    {
        private readonly DemoService _demoService;

        public DemoServiceTests()
        {
            _demoService = new DemoService();
        }

        [Fact]
        public void GetHello_ReturnHello_WhenCalling()
        {
            //Arrange
            var helloExpected = "HELLO WORLD";

            //Act
            var hello = _demoService.GetHello();

            //Assert
            Assert.Equal(helloExpected, hello);
        }
    }
}
