namespace CDSPracticalTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using CDSPractical;

    using Xunit;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Unit test class")]
    public sealed class CanGetLongestCommonWordTests
    {
        [Fact]
        public void BothListsEmpty_ThrowsArgumentException()
        {
            // Arrange
            var list1 = Enumerable.Empty<string>();
            var list2 = Enumerable.Empty<string>();

            // Act
            Action testCode = () => Questions.LongestCommonWord(list1, list2);

            // Assert
            Assert.Throws<ArgumentException>(testCode);
        }

        [Fact]
        public void List1IsEmpty_ThrowsArgumentException()
        {
            // Arrange
            var list1 = Enumerable.Empty<string>();
            var list2 = new List<string> { "irrelevantWord" };

            // Act
            Action testCode = () => Questions.LongestCommonWord(list1, list2);

            // Assert
            Assert.Throws<ArgumentException>(testCode);
        }

        [Fact]
        public void List2IsEmpty_ThrowsArgumentException()
        {
            // Arrange
            var list1 = new List<string> { "irrelevantWord" }; 
            var list2 = Enumerable.Empty<string>();

            // Act
            Action testCode = () => Questions.LongestCommonWord(list1, list2);

            // Assert
            Assert.Throws<ArgumentException>(testCode);
        }

        [Fact]
        public void BothListsAreNotEmpty_ButHaveNoElementInCommon_ThrowsArgumentException()
        {
            // Arrange
            var list1 = new List<string> { "word1" };
            var list2 = new List<string> { "word2" };

            // Act
            Action testCode = () => Questions.LongestCommonWord(list1, list2);

            // Assert
            Assert.Throws<ArgumentException>(testCode);
        }

        [Fact]
        public void BothListsAreNotEmpty_HaveOneElementInCommonButInDifferentCases_ThrowsArgumentException()
        {
            // Arrange
            const string CommonWord = "applepie";
            var list1 = new List<string> { "uniqueWord1", CommonWord.ToUpper(), "uncommonWord" };
            var list2 = new List<string> { "uniqueWord2", "someOtherWord", CommonWord.ToLower() };

            // Act
            Action testCode = () => Questions.LongestCommonWord(list1, list2);

            // Assert
            Assert.Throws<ArgumentException>(testCode);
        }

        [Fact]
        public void BothListsAreNotEmpty_HaveOneElementInCommon_ReturnsThatElement()
        {
            // Arrange
            const string CommonWord = "applePie";
            var list1 = new List<string> { "uniqueWord1", CommonWord, "uncommonWord" };
            var list2 = new List<string> { "uniqueWord2", "someOtherWord", CommonWord };

            // Act
            var actual = Questions.LongestCommonWord(list1, list2);

            // Assert
            Assert.Equal(CommonWord, actual);
        }

        [Fact]
        public void HaveMultipleElementsInCommon_ReturnsTheLongest()
        {
            // Arrange
            var list1 = new List<string> { "1", "333", "four", "IAmTheLongestWord" };
            var list2 = new List<string> { "333", "1", "IAmTheLongestWord", "four" };

            // Act
            var actual = Questions.LongestCommonWord(list1, list2);

            // Assert
            Assert.Equal("IAmTheLongestWord", actual);
        }
    }
}
