using ColorSupport;
using FakeItEasy;
using FakeItEasy.Configuration;
using Shouldly;
using Xunit;

namespace Color.Test.Public
{
    public class ColorStringTests
    {
        private readonly ITerminalSupport _terminalSupport;
        private readonly IHexToRgbConverter _hexToRgbConverter;
        private readonly IRgbToAnsi256Converter _ansiConverter;
        public ColorStringTests()
        {
            _terminalSupport = A.Fake<ITerminalSupport>();
            _hexToRgbConverter = A.Fake<IHexToRgbConverter>();
            _ansiConverter = A.Fake<IRgbToAnsi256Converter>();
        }

        [Fact]
        public void WithForeground_ShouldAddForeground_WhenColorSupported()
        {
            // Arrange
            A.CallTo(() => _terminalSupport.Level).Returns(SupportLevel.Basic);
            var value = "Dummy";

            // Act
            var colorString = new ColorString(
                value,
                _terminalSupport,
                _hexToRgbConverter,
                _ansiConverter).WithForeground(BasicColor.Red);

            // Assert
            colorString.ToString().ShouldBe($"\u001b[{(int)BasicColor.Red}m" + value + "\u001B[39m");
        }

        [Fact]
        public void WithBackground_ShouldAddBackground_WhenColorSupported()
        {
            // Arrange
            A.CallTo(() => _terminalSupport.Level).Returns(SupportLevel.Basic);
            var value = "Dummy";

            // Act
            var colorString = ((ColorString)value).WithBackground(BasicColor.Red);

            // Assert
            colorString.ToString().ShouldBe($"\u001b[{(int)BasicColor.Red + 10}m" + value + "\u001B[49m");
        }

        [Fact]
        public void WithStyle_WhenBold_ShouldShowCorrectTag()
        {
            // Arrange
            A.CallTo(() => _terminalSupport.Level).Returns(SupportLevel.TrueColor);
            var value = "Dummy";

            // Act
            var colorString = new ColorString(
                value,
                _terminalSupport,
                _hexToRgbConverter,
                _ansiConverter).WithStyle(TextStyle.Bold);

            // Assert
            colorString.ToString().ShouldBe($"\u001B[{TextStyle.Bold.Open}m" + value + $"\u001B[{TextStyle.Bold.Close}m");
        }
        [Fact]
        public void WithStyle_WhenReset_ShouldShowCorrectTag()
        {
            // Arrange
            A.CallTo(() => _terminalSupport.Level).Returns(SupportLevel.TrueColor);
            var value = "Dummy";

            // Act
            var colorString = new ColorString(
                value,
                _terminalSupport,
                _hexToRgbConverter,
                _ansiConverter).WithStyle(TextStyle.Reset);

            // Assert
            colorString.ToString().ShouldBe($"\u001B[{TextStyle.Reset.Open}m" + value + $"\u001B[{TextStyle.Reset.Close}m");
        }
        [Fact]
        public void WithStyle_WhenDim_ShouldShowCorrectTag()
        {
            // Arrange
            A.CallTo(() => _terminalSupport.Level).Returns(SupportLevel.TrueColor);
            var value = "Dummy";

            // Act
            var colorString = new ColorString(
                value,
                _terminalSupport,
                _hexToRgbConverter,
                _ansiConverter).WithStyle(TextStyle.Dim);

            // Assert
            colorString.ToString().ShouldBe($"\u001B[{TextStyle.Dim.Open}m" + value + $"\u001B[{TextStyle.Dim.Close}m");
        }

        [Fact]
        public void WithStyle_WhenItalic_ShouldShowCorrectTag()
        {
            // Arrange
            A.CallTo(() => _terminalSupport.Level).Returns(SupportLevel.TrueColor);
            var value = "Dummy";

            // Act
            var colorString = new ColorString(
                value,
                _terminalSupport,
                _hexToRgbConverter,
                _ansiConverter).WithStyle(TextStyle.Italic);

            // Assert
            colorString.ToString().ShouldBe($"\u001B[{TextStyle.Italic.Open}m" + value + $"\u001B[{TextStyle.Italic.Close}m");
        }
        [Fact]
        public void WithStyle_WhenUnderline_ShouldShowCorrectTag()
        {
            // Arrange
            A.CallTo(() => _terminalSupport.Level).Returns(SupportLevel.TrueColor);
            var value = "Dummy";

            // Act
            var colorString = new ColorString(
                value,
                _terminalSupport,
                _hexToRgbConverter,
                _ansiConverter).WithStyle(TextStyle.Underline);

            // Assert
            colorString.ToString().ShouldBe($"\u001B[{TextStyle.Underline.Open}m" + value + $"\u001B[{TextStyle.Underline.Close}m");
        }

        [Fact]
        public void WithStyle_WhenOverline_ShouldShowCorrectTag()
        {
            // Arrange
            A.CallTo(() => _terminalSupport.Level).Returns(SupportLevel.TrueColor);
            var value = "Dummy";

            // Act
            var colorString = new ColorString(
                value,
                _terminalSupport,
                _hexToRgbConverter,
                _ansiConverter).WithStyle(TextStyle.Overline);

            // Assert
            colorString.ToString().ShouldBe($"\u001B[{TextStyle.Overline.Open}m" + value + $"\u001B[{TextStyle.Overline.Close}m");
        }

        [Fact]
        public void WithStyle_WhenInverse_ShouldShowCorrectTag()
        {
            // Arrange
            A.CallTo(() => _terminalSupport.Level).Returns(SupportLevel.TrueColor);
            var value = "Dummy";

            // Act
            var colorString = new ColorString(
                value,
                _terminalSupport,
                _hexToRgbConverter,
                _ansiConverter).WithStyle(TextStyle.Inverse);

            // Assert
            colorString.ToString().ShouldBe($"\u001B[{TextStyle.Inverse.Open}m" + value + $"\u001B[{TextStyle.Inverse.Close}m");
        }

        [Fact]
        public void WithStyle_WhenHidden_ShouldShowCorrectTag()
        {
            // Arrange
            A.CallTo(() => _terminalSupport.Level).Returns(SupportLevel.TrueColor);
            var value = "Dummy";

            // Act
            var colorString = new ColorString(
                value,
                _terminalSupport,
                _hexToRgbConverter,
                _ansiConverter).WithStyle(TextStyle.Hidden);

            // Assert
            colorString.ToString().ShouldBe($"\u001B[{TextStyle.Hidden.Open}m" + value + $"\u001B[{TextStyle.Hidden.Close}m");
        }

        [Fact]
        public void WithStyle_WhenStrikeThrough_ShouldShowCorrectTag()
        {
            // Arrange
            A.CallTo(() => _terminalSupport.Level).Returns(SupportLevel.TrueColor);
            var value = "Dummy";

            // Act
            var colorString = new ColorString(
                value,
                _terminalSupport,
                _hexToRgbConverter,
                _ansiConverter).WithStyle(TextStyle.StrikeThrough);

            // Assert
            colorString.ToString().ShouldBe($"\u001B[{TextStyle.StrikeThrough.Open}m" + value + $"\u001B[{TextStyle.StrikeThrough.Close}m");
        }
        
        [Fact]
        public void WithForeground_WithRgb_ShouldShowCorrectTag_WhenSupportedLevelIsTrueColor()
        {
            // Arrange
            A.CallTo(() => _terminalSupport.Level).Returns(SupportLevel.TrueColor);
            var r = 5; var g = 6; var b = 7;
            var value = "Dummy";

            // Act
            var colorString = new ColorString(
                value,
                _terminalSupport,
                _hexToRgbConverter,
                _ansiConverter).WithForeground(r, g, b);

            // Assert
            ((string)colorString).ShouldBe($"\u001B[38;2;{r};{g};{b}m" + value + "\u001B[39m");
        }
        [Fact]
        public void WithBackground_WithRgb_ShouldShowCorrectTag_WhenSupportedLevelIsTrueColor()
        {
            // Arrange
            A.CallTo(() => _terminalSupport.Level).Returns(SupportLevel.TrueColor);
            var r = 5; var g = 6; var b = 7;
            var value = "Dummy";

            // Act
            var colorString = new ColorString(
                value,
                _terminalSupport,
                _hexToRgbConverter,
                _ansiConverter).WithBackground(r, g, b);

            // Assert
            ((string)colorString).ShouldBe($"\u001B[48;2;{r};{g};{b}m" + value + "\u001B[49m");
        }
        [Fact]
        public void WithForeground_WithRgb_ShouldConvertToAnsi256_WhenSupportedLevelIs256()
        {
            // Arrange
            A.CallTo(() => _terminalSupport.Level).Returns(SupportLevel.Color256);
            var convertedColor = Ansi256Color.CadetBlue;
            AnsiConverterCall.Returns(convertedColor);
            var value = "Dummy";

            // Act
            var colorString = new ColorString(
                value,
                _terminalSupport,
                _hexToRgbConverter,
                _ansiConverter).WithForeground(5, 6, 7);

            // Assert
            ((string)colorString).ShouldBe($"\u001B[38;5;{(int)convertedColor}m" + value + "\u001B[39m");
        }
        [Fact]
        public void WithForeground_WithHex_ShouldConvertToAnsi256_WhenSupportedLevelIs256()
        {
            // Arrange
            A.CallTo(() => _terminalSupport.Level).Returns(SupportLevel.Color256);
            var convertedColor = Ansi256Color.CadetBlue;
            AnsiConverterCall.Returns(convertedColor);
            var value = "Dummy";

            // Act
            var colorString = new ColorString(
                value,
                _terminalSupport,
                _hexToRgbConverter,
                _ansiConverter).WithForeground("dummyValue");

            // Assert
            colorString.ToString().ShouldBe($"\u001B[38;5;{(int)convertedColor}m" + value + "\u001B[39m");
        }

        [Fact]
        public void WithBackground_WithRgb_ShouldConvertToAnsi256_WhenSupportedLevelIs256()
        {
            // Arrange
            A.CallTo(() => _terminalSupport.Level).Returns(SupportLevel.Color256);
            var convertedColor = Ansi256Color.CadetBlue;
            AnsiConverterCall.Returns(convertedColor);
            var value = "Dummy";

            // Act
            var colorString = new ColorString(
                value,
                _terminalSupport,
                _hexToRgbConverter,
                _ansiConverter).WithBackground(5, 6, 7);

            // Assert
            colorString.ToString().ShouldBe($"\u001B[48;5;{(int)convertedColor}m" + value + "\u001B[49m");
        }

        [Fact]
        public void WithBackground_WithHex_ShouldConvertToAnsi256_WhenSupportedLevelIs256()
        {
            // Arrange
            A.CallTo(() => _terminalSupport.Level).Returns(SupportLevel.Color256);
            var convertedColor = Ansi256Color.CadetBlue;
            AnsiConverterCall.Returns(convertedColor);
            var value = "Dummy";

            // Act
            var colorString = new ColorString(
                value,
                _terminalSupport,
                _hexToRgbConverter,
                _ansiConverter).WithBackground("dummyValue");

            // Assert
            colorString.ToString().ShouldBe($"\u001B[48;5;{(int)convertedColor}m" + value + "\u001B[49m");
        }

        [Fact]
        public void WithBackground_ShouldNotAddBackground_WhenColorNotSupported()
        {
            // Arrange
            A.CallTo(() => _terminalSupport.Level).Returns(SupportLevel.None);
            var value = "Dummy";

            // Act
            var colorString = new ColorString(
                value,
                _terminalSupport,
                _hexToRgbConverter,
                _ansiConverter).WithBackground(BasicColor.Red);

            // Assert
            colorString.ToString().ShouldBe(value);
        }

        [Fact]
        public void WithForeground_ShouldNotAddForeground_WhenColorNotSupported()
        {
            // Arrange
            A.CallTo(() => _terminalSupport.Level).Returns(SupportLevel.None);
            var value = "Dummy";

            // Act
            var colorString = new ColorString(
                value,
                _terminalSupport,
                _hexToRgbConverter,
                _ansiConverter).WithForeground(BasicColor.Red);

            // Assert
            colorString.ToString().ShouldBe(value);
        }

        [Fact]
        public void WithStyle_ShouldNotAddStyle_WhenColorNotSupported()
        {
            // Arrange
            A.CallTo(() => _terminalSupport.Level).Returns(SupportLevel.None);
            var value = "Dummy";

            // Act
            var colorString = new ColorString(
                value,
                _terminalSupport,
                _hexToRgbConverter,
                _ansiConverter).WithStyle(TextStyle.Bold);

            // Assert
            colorString.ToString().ShouldBe(value);
        }

        private IReturnValueArgumentValidationConfiguration<Ansi256Color> AnsiConverterCall =>
                A.CallTo(() => _ansiConverter.GetClosest(A<(int, int, int)>._));
    }
}