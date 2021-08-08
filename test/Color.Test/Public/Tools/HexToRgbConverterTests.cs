using Color;
using Shouldly;
using Xunit;

namespace Color.Test.Public.Tools
{
    public class HexToRgbConverterTests
    {
        private readonly HexToRgbConverter _converter;
        public HexToRgbConverterTests()
        {
            _converter = new HexToRgbConverter();
        }
        [Theory]
        [InlineData(128, 114, 123, "#80727b")]
        [InlineData(244, 44, 4, "#f42c04")]
        [InlineData(0, 0, 0, "#000000")]
        [InlineData(255, 255, 255, "#ffffff")]
        public void RgbToHex_ConvertsRgbToHex(int red, int green, int blue, string expectedHex)
        {
            // Act
            var result = _converter.RgbToHex(
                red,
                green,
                blue);

            // Assert
            expectedHex.ShouldBe(result);
        }

        [Theory]
        [InlineData("#80727b", 128, 114, 123)]
        [InlineData("#f42c04", 244, 44, 4)]
        [InlineData("#000000", 0, 0, 0)]
        [InlineData("#ffffff", 255, 255, 255)]
        public void HexToRgb_ConvertsHexToRgb(string hex, int red, int green, int blue)
        {
            // Act
            var result = _converter.HexToRgb(hex);

            // Assert
            (red, green, blue).ShouldBe(result);
        }
    }
}