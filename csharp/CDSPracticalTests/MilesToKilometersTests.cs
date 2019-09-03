namespace CDSPracticalTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using CDSPractical;

    using Xunit;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Unit test class")]
    public sealed class MilesToKilometersTests
    {
        [Fact]
        public void ZeroMiles_Returns0Kilometers()
        {
            // Arrange
            var miles = 0.0;

            // Act
            var kms = miles.ToKilometers();

            // Assert
            Assert.Equal(0.0, kms);
        }

        [Fact]
        public void NegativeMiles_ReturnsNegativeKilometers()
        {
            // Arrange
            var miles = -2.0;

            // Act
            var kms = miles.ToKilometers();

            // Assert
            Assert.True(Math.Abs(-3.2 - kms) < 0.0000000001); // used to compensate for double's lack of precision
        }

        [Fact]
        public void PositiveMiles_ReturnsPositiveKilometers()
        {
            // Arrange
            var miles = 3.0;

            // Act
            var kms = miles.ToKilometers();

            // Assert
            Assert.True(Math.Abs(4.8 - kms) < 0.0000000001); // used to compensate for double's lack of precision
        }
    }
}