namespace CDSPracticalTests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using CDSPractical;

    using Xunit;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Unit test class")]
    public sealed class ShuffleTests
    {
        [Fact]
        public void EmptyInput_ReturnsEmptyInput()
        {
            // Arrange
            var input = Enumerable.Empty<int>();

            // Act
            var actual = input.Shuffle();

            // Assert
            Assert.Empty(actual);
        }

        [Fact]
        public void OneElementInput_ReturnsThatSameElement()
        {
            // Arrange
            var input = new List<int> { 1 };

            // Act
            var actual = input.Shuffle();

            // Assert
            Assert.Single(actual);
            Assert.Equal(1, actual.Single());
        }

        [Fact]
        public void EvenNumberOfElements_ReturnsAListOfFirstHalfIntertwinedWithReversedSecondHalf()
        {
            // Arrange
            var input = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var expected = new[] { 10, 1, 9, 2, 8, 3, 7, 4, 6, 5 };

            // Act
            var actual = input.Shuffle();

            // Assert
            Assert.Equal(expected.OrderBy(x => x), actual.OrderBy(x => x));
        }

        [Fact]
        public void OddNumberOfElements_ReturnsAListOfFirstHalfIntertwinedWithReversedSecondHalfAndMiddleUnchanged()
        {
            // Arrange
            var input = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            var expected = new[] { 1, 11, 2, 10, 3,   6,   9, 4, 8, 5, 7 };

            // Act
            var actual = input.Shuffle();

            // Assert
            Assert.Equal(expected.OrderBy(x => x), actual.OrderBy(x => x));
        }
    }
}