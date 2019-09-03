namespace CDSPracticalTests
{
    using System.Diagnostics.CodeAnalysis;

    using CDSPractical;

    using Xunit;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Unit test class")]
    public sealed class IsPalindromeTests
    {
        [Fact]
        public void EmptyString_ReturnsTrue()
        {
            // Arrange
            var input = string.Empty;

            // Assert
            var actual = input.IsPalindrome();

            // Assert
            Assert.True(actual);
        }

        [Theory]
        [InlineData("abcde")]
        [InlineData("IAmNotAPalindrome")]
        public void NonPalindrome_ReturnsFalse(string input)
        {
            // Arrange

            // Assert
            var actual = input.IsPalindrome();

            // Assert
            Assert.False(actual);
        }

        [Theory]
        [InlineData("abcdedcba")]
        [InlineData("palindromeemordnilap")]
        public void Palindrome_ReturnsTrue(string input)
        {
            // Arrange

            // Assert
            var actual = input.IsPalindrome();

            // Assert
            Assert.True(actual);
        }
    }
}