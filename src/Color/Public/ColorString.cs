using System.Collections.Generic;
using System.Text;
using ColorSupport;

namespace Color
{
    public class ColorString
    {
        private const int ANSI_BACKGROUND_OFFSET = 10;
        private const string foregroundClose = "\u001B[39m";
        private const string backgroundClose = "\u001B[49m";
        private readonly SupportLevel _supportLevel;
        private readonly IHexToRgbConverter _hexToRgbConverter;
        private readonly IRgbToAnsi256Converter _rbgToAnsi256Conveter;
        private readonly string _value;
        private string _foreground;
        private string _background;
        private List<(int Open, int Close)> _textStyles = new();
        internal ColorString(
            string value,
            ITerminalSupport terminalSupport,
            IHexToRgbConverter hexToRgbConverter,
            IRgbToAnsi256Converter ansi256Converter)
        {
            _value = value;
            _supportLevel = terminalSupport.Level;
            _hexToRgbConverter = hexToRgbConverter;
            _rbgToAnsi256Conveter = ansi256Converter;
        }
        internal ColorString WithBackground(BasicColor color)
        {
            _background = ToBasicTag(color, ANSI_BACKGROUND_OFFSET);
            return this;
        }

        internal ColorString WithForeground(BasicColor color)
        {
            _foreground = ToBasicTag(color);
            return this;
        }

        internal ColorString WithForeground(string hexCode)
        {
            var (r, g, b) = _hexToRgbConverter.HexToRgb(hexCode);
            WithForeground(r, g, b);
            return this;
        }

        internal ColorString WithBackground(string hexCode)
        {
            var (r, g, b) = _hexToRgbConverter.HexToRgb(hexCode);
            WithBackground(r, g, b);
            return this;
        }

        internal ColorString WithForeground(int r, int g, int b)
        {
            if (_supportLevel == SupportLevel.TrueColor)
            {
                _foreground = ToAnsi16Tag(r, g, b);
            }

            if (_supportLevel == SupportLevel.Color256)
            {
                _foreground = To256Tag(RgbTo256(r, g, b));
            }
            return this;
        }

        internal ColorString WithBackground(int r, int g, int b)
        {
            if (_supportLevel == SupportLevel.TrueColor)
            {
                _background = ToAnsi16Tag(r, g, b, ANSI_BACKGROUND_OFFSET);
            }

            if (_supportLevel == SupportLevel.Color256)
            {
                _background = To256Tag(RgbTo256(r, g, b), ANSI_BACKGROUND_OFFSET);
            }
            return this;
        }

        internal ColorString WithStyle((int Open, int Close) style)
        {
            _textStyles.Add(style);
            return this;
        }

        public static implicit operator string(ColorString value) => value.ToFormattedString();
        public static explicit operator ColorString(string value) => new ColorString(
            value,
            new TerminalSupport(),
            new HexToRgbConverter(),
            new RgbToAnsi256Converter());

        private string StartTag()
        {
            var builder = new StringBuilder($"{_foreground ?? string.Empty}{_background ?? string.Empty}");
            foreach (var style in _textStyles)
            {
                builder.Append($"\u001B[{style.Open}m");
            }
            return builder.ToString();
        }
        private string EndTag()
        {
            var builder = new StringBuilder();
            foreach (var style in _textStyles)
            {
                builder.Append($"\u001B[{style.Close}m");
            }
            builder.Append($"{(string.IsNullOrEmpty(_foreground) ? string.Empty : foregroundClose)}{(string.IsNullOrEmpty(_background) ? string.Empty : backgroundClose)}");
            return builder.ToString();
        }


        private int RgbTo256(int red, int green, int blue)
        {
            var ansi = _rbgToAnsi256Conveter.GetClosest((red, green, blue));

            return (int)ansi;
        }
        private string ToFormattedString()
        {
            if (_supportLevel == SupportLevel.None)
            {
                return _value;
            }
            return $"{StartTag()}{_value}{EndTag()}";
        }

        public override string ToString()
        {
            return ToFormattedString();
        }
        private static string ToBasicTag(BasicColor color, int offset = 0) => $"\u001b[{(int)color + offset}m";
        private static string To256Tag(int color, int offset = 0) => $"\u001B[{38+ offset};5;{color}m";
        private static string ToAnsi16Tag(int r, int g, int b, int offset = 0) =>
        $"\u001B[{38 + offset};2;{r};{g};{b}m";
    }
}