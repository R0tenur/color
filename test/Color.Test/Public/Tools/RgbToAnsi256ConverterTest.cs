using FakeItEasy;
using FakeItEasy.Configuration;
using Shouldly;
using Xunit;

namespace Color.Test.Public.Tools
{
    public class RgbToAnsi256ConverterTest
    {
        private readonly RgbToAnsi256Converter _converter;
        private readonly IColorDistance _distance;
        public RgbToAnsi256ConverterTest()
        {
            _distance = A.Fake<IColorDistance>();
            _converter = new RgbToAnsi256Converter(_distance);
        }
        [Fact]
        public void GetClosests_CachesResponseAndItterateOnlyOnce()
        {
            // Arrange
            var call = ACallWith((1, 1, 1));
            call.Returns(1);
            // Act

            _converter.GetClosest((1, 1, 1));
            _converter.GetClosest((1, 1, 1));
            _converter.GetClosest((1, 1, 1));
            _converter.GetClosest((1, 1, 1));

            // Assert
            call.MustHaveHappenedANumberOfTimesMatching(i => i == 256);
        }

        [Fact]
        public void GetClosests_ShouldStopLoopIfExactColorFound()
        {
            // Arrange
            var call = ACallWith((2, 2, 2));
            call.Returns(0);
            // Act

            _converter.GetClosest((2, 2, 2));

            // Assert
            call.MustHaveHappenedANumberOfTimesMatching(i => i == 2);
        }

        [Fact]
        public void GetClosests_ShouldSetNewColorWHenDistanceIsShorter()
        {
            // Arrange
            var call = ACallWith((1, 2, 3));
            call
                .Returns(100)
                .Once()
                .Then
                .Returns(50)
                .Once()
                .Then
                .Returns(100);

            // Act
            var color = _converter.GetClosest((1, 2, 3));

            // Assert
            color.ShouldBe(Ansi256Color.Maroon);
        }

        private IReturnValueArgumentValidationConfiguration<double> ACallWith((int red, int green, int blue) input) =>
            A.CallTo(() => _distance.GetDistance(input, A<(int, int, int)>._));

    }
}