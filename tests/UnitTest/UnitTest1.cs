using FluentAssertions;
using Xunit;

namespace UnitTest;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        true.Should().BeTrue();
    }
}
