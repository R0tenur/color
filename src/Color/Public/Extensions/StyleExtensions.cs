using System.Diagnostics.CodeAnalysis;

namespace Color
{
    [ExcludeFromCodeCoverage]
    public static class StyleExtensions
    {
        public static ColorString Reset(this string input) => WithStyle(TextStyle.Reset, input);
        public static ColorString Reset(this ColorString input) => WithStyle(TextStyle.Reset, input);
        public static ColorString Bold(this string input) => WithStyle(TextStyle.Bold, input);
        public static ColorString Bold(this ColorString input) => WithStyle(TextStyle.Bold, input);
        public static ColorString Dim(this string input) => WithStyle(TextStyle.Dim, input);
        public static ColorString Dim(this ColorString input) => WithStyle(TextStyle.Dim, input);
        public static ColorString Italic(this string input) => WithStyle(TextStyle.Italic, input);
        public static ColorString Italic(this ColorString input) => WithStyle(TextStyle.Italic, input);
        public static ColorString Underline(this string input) => WithStyle(TextStyle.Underline, input);
        public static ColorString Underline(this ColorString input) => WithStyle(TextStyle.Underline, input);
        public static ColorString Overline(this string input) => WithStyle(TextStyle.Overline, input);
        public static ColorString Overline(this ColorString input) => WithStyle(TextStyle.Overline, input);
        public static ColorString Inverse(this string input) => WithStyle(TextStyle.Inverse, input);
        public static ColorString Inverse(this ColorString input) => WithStyle(TextStyle.Inverse, input);
        public static ColorString Hidden(this string input) => WithStyle(TextStyle.Hidden, input);
        public static ColorString Hidden(this ColorString input) => WithStyle(TextStyle.Hidden, input);
        public static ColorString StrikeThrough(this string input) => WithStyle(TextStyle.StrikeThrough, input);
        public static ColorString StrikeThrough(this ColorString input) => WithStyle(TextStyle.StrikeThrough, input);
        private static ColorString WithStyle((int Open, int Close) style, string input) => WithStyle(style, (ColorString)input);
        private static ColorString WithStyle((int Open, int Close) style, ColorString input) => ((ColorString)input).WithStyle(style);
    }
}