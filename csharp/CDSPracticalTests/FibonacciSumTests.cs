namespace CDSPracticalTests
{
    using System.Diagnostics.CodeAnalysis;

    using CDSPractical;

    using Xunit;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Unit test class")]
    public sealed class FibonacciSumTests
    {
        [Theory]
        [InlineData(10, 10)]
        [InlineData(100, 44)]
        [InlineData(1000, 798)]
        [InlineData(4000000, 4613732)]
        public void FibonacciSum_ComputesCorrectResult(int maximumBound, int expected)
        {
            // Arrange

            // Act
            var actual = Questions.FibonacciSum(maximumBound);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}