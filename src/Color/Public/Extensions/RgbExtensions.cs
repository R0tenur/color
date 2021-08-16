using System.Diagnostics.CodeAnalysis;

namespace Color
{
    [ExcludeFromCodeCoverage]
    public static class RgbExtensions {
        public static ColorString Color(this string input, string hexCode) => ((ColorString)input).Color(hexCode);
        public static ColorString Color (this ColorString input, string hexCode) => input.WithForeground (hexCode);
        public static ColorString Color(this string input, int red, int green, int blue) => ((ColorString)input).Color(red, green, blue);
        public static ColorString Color(this ColorString input, int red, int green, int blue) => input.WithForeground(red, green, blue);

    }
}