namespace CDSPracticalTests 
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using CDSPractical;

    using Xunit;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Unit test class")]
    public sealed class GenerateListTests
    {

        [Fact]
        public void CanGenerateListOfNumbers()
        {
            // Arrange

            // Act
            var actual = Questions.GenerateList(0);

            // Assert
            Assert.Equal(Enumerable.Range(1, 100), actual);
        }
    }
}
