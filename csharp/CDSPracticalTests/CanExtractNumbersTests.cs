namespace CDSPracticalTests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using CDSPractical;

    using Xunit;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Unit test class")]
    public sealed class CanExtractNumbersTests
    {
        [Fact]
        public void EmptyList_ReturnsEmptyList()
        {
            // Arrange

            // Act

            // Assert
            Assert.Empty(Questions.ExtractNumbers(Enumerable.Empty<string>()));
        }

        [Fact]
        public void NonEmptyList_DoesNotContainIntegers_ReturnsEmptyList()
        {
            // Arrange
            var input = new List<string> { "hello", "there" };

            // Act
            var actual = Questions.ExtractNumbers(input);

            // Assert
            Assert.Empty(actual);
        }

        [Fact]
        public void NonEmptyList_OnlyContainsIntegers_ReturnsThoseNumbers()
        {
            // Arrange
            var input = new List<string> { "123", "456" };

            // Act
            var actual = Questions.ExtractNumbers(input);

            // Assert
            Assert.Equal(input.Count, actual.Count());
            Assert.Equal(123, actual.First());
            Assert.Equal(456, actual.Skip(1).First());
        }

        [Fact]
        public void NonEmptyList_ContainsIntegersFloatsDecimalsAndString_ReturnsOnlyInts()
        {
            // Arrange
            var input = new List<string> { "123", "abc", "123.45", "999.99M" };

            // Act
            var actual = Questions.ExtractNumbers(input);

            // Assert
            Assert.Single(actual);
            Assert.Equal(123, actual.Single());
        }
    }
}
