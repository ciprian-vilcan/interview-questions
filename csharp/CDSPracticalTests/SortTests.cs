namespace CDSPracticalTests
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using CDSPractical;

    using Xunit;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Unit test class")]
    public sealed class SortTests
    {
        [Fact]
        public void EmptyInput_ReturnsEmptyInput()
        {
            // Arrange
            var input = new int[0];

            // Act
            var actual = input.Sort();

            // Assert
            Assert.Empty(actual);
        }

        [Fact]
        public void OneElementInput_ReturnsElement()
        {
            // Arrange
            var input = new[] { 12 };

            // Act
            var actual = input.Sort();

            // Assert
            Assert.Single(actual);
            Assert.Equal(input.Single(), actual.Single());
        }

        [Fact]
        public void AlreadySortedInput_RemainsSorted()
        {
            // Arrange
            var input = new[] { 12, 24 };

            // Act
            var actual = input.Sort();

            // Assert
            Assert.Equal(input.Length, actual.Length);
            Assert.Equal(input[0], actual[0]);
            Assert.Equal(input[1], actual[1]);
        }

        [Fact]
        public void UnsortedInput_ReturnsSorted()
        {
            // Arrange
            var input = new[] { 3, 2, 4 };
            var expected = new[] { 2, 3, 4 };

            // Act
            var actual = input.Sort();

            // Assert
            Assert.Equal(input.Length, actual.Length);
            Assert.Equal(expected.OrderBy(x => x), actual.OrderBy(x => x));
        }
    }
}