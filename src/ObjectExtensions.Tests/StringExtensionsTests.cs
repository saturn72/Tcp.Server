using System;
using Shouldly;
using Xunit;

namespace ObjectExtensions.Tests
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void StringExtensions_HasValue_ShouldReturnsFalse(string source)
        {
            source.HasValue().ShouldBeFalse();
        }

        [Fact]
        public void StringExtensions_HasValue_ShouldReturnTrue()
        {
            "This is data".HasValue().ShouldBeTrue();
        }
    }
}
