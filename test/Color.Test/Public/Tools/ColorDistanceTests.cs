using FakeItEasy;
using Shouldly;
using Xunit;

namespace Color.Test.Public.Tools
{
    public class ColorDistanceTests
    {
        private readonly ColorDistance _distance;
        private readonly IHexToRgbConverter _hexToRgb;
        public ColorDistanceTests()
        {
            _hexToRgb = A.Fake<IHexToRgbConverter>();
            _distance = new ColorDistance(_hexToRgb);
        }

        [Fact]
        public void GetDistance_ReturnsZeroBetweenSameColor()
        {
            // Act
            var result = _distance.GetDistance((1, 1, 1), (1, 1, 1));

            // Assert
            result.ShouldBe(0);
        }

        [Fact]
        public void GetDistance_Returns765BetweenBlackAndWhite()
        {
            // Act
            var result = new ColorDistance().GetDistance((0, 0, 0), (255, 255, 255));

            // Assert
            result.ShouldBe(765);
        }

        [Fact]
        public void GetDistance_WithHexCodeReturns765BetweenBlackAndWhite()
        {
            // Arrange
            A.CallTo(() => _hexToRgb.HexToRgb("#000000")).Returns((0, 0, 0));
            A.CallTo(() => _hexToRgb.HexToRgb("#ffffff")).Returns((255, 255, 255));
            // Act
            var result = _distance.GetDistance("#000000", "#ffffff");

            // Assert
            result.ShouldBe(765);
        }
    }
}