using ColorChecker.Domain;
using ColorChecker.Domain.Services.CustomExceptions;
using Xunit;

namespace PixelTestSuite
{
    public class PixelEntityTestSuite
    {

        [Fact]
        public void Validate_InputValidDTO_ReturnNoException()
        {
            // Arrange
            var pixel = new Pixel
            {
                Color = "Red",
                Intensity = 10,
                Name = "Test",
            };

            // Act
            var exception = Record.Exception(() => { pixel.Validate(); });

            // Assert
            Assert.True(exception is null);
        }

        [Fact]
        public void Validate_InputInvalidIntensityDTO_ReturnException()
        {
            // Arrange
            var pixel = new Pixel
            {
                Color = "Red",
                Intensity = 200,
                Name = "Test2",
            };

            // Act
            var exception = Record.Exception(() => { pixel.Validate(); });

            // Assert
            Assert.IsType<ParsingReqPayloadException>(exception);
        }

        [Fact]
        public void Validate_InputInvalidColorDTO_ReturnException()
        {
            // Arrange
            var pixel = new Pixel
            {
                Color = "Yellow",
                Intensity = 90,
                Name = "Test3",
            };

            // Act
            var exception = Record.Exception(() => { pixel.Validate(); });

            // Assert
            Assert.IsType<ParsingReqPayloadException>(exception);
        }

    }
}
