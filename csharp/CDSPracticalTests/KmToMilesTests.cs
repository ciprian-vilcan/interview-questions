namespace CDSPracticalTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using CDSPractical;

    using Xunit;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Unit test class")]
    public sealed class KmToMilesTests
    {
        [Fact]
        public void ZeroKilometers_Returns0Miles()
        {
            // Arrange
            var kms = 0.0;

            // Act
            var miles = kms.ToMiles();

            // Assert
            Assert.Equal(0.0, miles);
        }

        [Fact]
        public void NegativeKilometers_ReturnsNegativeMiles()
        {
            // Arrange
            var kms = -3.2;

            // Act
            var miles = kms.ToMiles();

            // Assert
            Assert.True(Math.Abs(-2 - miles) < 0.0000000001); // used to compensate for double's lack of precision
        }

        [Fact]
        public void PositiveKilometers_ReturnsPositiveMiles()
        {
            // Arrange
            var kms = 4.8;

            // Act
            var miles = kms.ToMiles();

            // Assert
            Assert.True(Math.Abs(3 - miles) < 0.0000000001); // used to compensate for double's lack of precision
        }
    }
}