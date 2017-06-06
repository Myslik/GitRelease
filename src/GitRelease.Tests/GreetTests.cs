using GitRelease.CLI;
using Xunit;

namespace GitRelease.Tests
{
    public class GreetTests
    {
        [Fact]
        public void GreetHelloWorldTest()
        {
            var greet = new Greet();
            var actual = greet.Hello("world");
            Assert.Equal("Hello world!", actual);
        }
    }
}
