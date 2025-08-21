using Xunit;
using Library.UnitTests;

public class HelloWorldTests
{
    [Fact]
    public void HelloWorld_ReturnsExpectedString()
    {
        var result = HelloWorld.GetGreeting();
        Assert.Equal("Hello, World!", result);
    }
}