using System.Diagnostics.CodeAnalysis;

namespace Color
{
    [ExcludeFromCodeCoverage]
    public static class BasicColorExtensions {
        public static ColorString DarkRed (this string input) => BasicForeground (BasicColor.DarkRed, input);
        public static ColorString DarkRed (this ColorString input) => BasicForeground (BasicColor.DarkRed, input);
        public static ColorString Red (this string input) => BasicForeground (BasicColor.Red, input);
        public static ColorString Red (this ColorString input) => BasicForeground (BasicColor.Red, input);
        public static ColorString Purple (this string input) => BasicForeground (BasicColor.Purple, input);
        public static ColorString Purple (this ColorString input) => BasicForeground (BasicColor.Purple, input);
        public static ColorString Pink (this string input) => BasicForeground (BasicColor.Pink, input);
        public static ColorString Pink (this ColorString input) => BasicForeground (BasicColor.Pink, input);
        public static ColorString Cyan (this string input) => BasicForeground (BasicColor.Cyan, input);
        public static ColorString Cyan (this ColorString input) => BasicForeground (BasicColor.Cyan, input);
        public static ColorString DarkCyan (this string input) => BasicForeground (BasicColor.DarkCyan, input);
        public static ColorString DarkCyan (this ColorString input) => BasicForeground (BasicColor.DarkCyan, input);
        public static ColorString DarkBlue (this string input) => BasicForeground (BasicColor.DarkBlue, input);
        public static ColorString DarkBlue (this ColorString input) => BasicForeground (BasicColor.DarkBlue, input);
        public static ColorString Blue (this string input) => BasicForeground (BasicColor.Blue, input);
        public static ColorString Blue (this ColorString input) => BasicForeground (BasicColor.Blue, input);
        public static ColorString Green (this string input) => BasicForeground (BasicColor.Green, input);
        public static ColorString Green (this ColorString input) => BasicForeground (BasicColor.Green, input);
        public static ColorString DarkGreen (this string input) => BasicForeground (BasicColor.DarkGreen, input);
        public static ColorString DarkGreen (this ColorString input) => BasicForeground (BasicColor.DarkGreen, input);
        public static ColorString DarkYellow (this string input) => BasicForeground (BasicColor.DarkYellow, input);
        public static ColorString DarkYellow (this ColorString input) => BasicForeground (BasicColor.DarkYellow, input);
        public static ColorString Yellow (this string input) => BasicForeground (BasicColor.Yellow, input);
        public static ColorString Yellow (this ColorString input) => BasicForeground (BasicColor.Yellow, input);
        public static ColorString Grey (this string input) => BasicForeground (BasicColor.Grey, input);
        public static ColorString Grey (this ColorString input) => BasicForeground (BasicColor.Grey, input);
        public static ColorString DarkGrey (this string input) => BasicForeground (BasicColor.DarkGrey, input);
        public static ColorString DarkGrey (this ColorString input) => BasicForeground (BasicColor.DarkGrey, input);
        public static ColorString Black (this string input) => BasicForeground (BasicColor.Black, input);
        public static ColorString Black (this ColorString input) => BasicForeground (BasicColor.Black, input);
        public static ColorString BgDarkRed (this string input) => BasicBackground (BasicColor.DarkRed, input);
        public static ColorString BgDarkRed (this ColorString input) => BasicBackground (BasicColor.DarkRed, input);
        public static ColorString BgRed (this string input) => BasicBackground (BasicColor.Red, input);
        public static ColorString BgRed (this ColorString input) => BasicBackground (BasicColor.Red, input);
        public static ColorString BgPurple (this string input) => BasicBackground (BasicColor.Purple, input);
        public static ColorString BgPurple (this ColorString input) => BasicBackground (BasicColor.Purple, input);
        public static ColorString BgPink (this string input) => BasicBackground (BasicColor.Pink, input);
        public static ColorString BgPink (this ColorString input) => BasicBackground (BasicColor.Pink, input);
        public static ColorString BgCyan (this string input) => BasicBackground (BasicColor.Cyan, input);
        public static ColorString BgCyan (this ColorString input) => BasicBackground (BasicColor.Cyan, input);
        public static ColorString BgDarkCyan (this string input) => BasicBackground (BasicColor.DarkCyan, input);
        public static ColorString BgDarkCyan (this ColorString input) => BasicBackground (BasicColor.DarkCyan, input);
        public static ColorString BgDarkBlue (this string input) => BasicBackground (BasicColor.DarkBlue, input);
        public static ColorString BgDarkBlue (this ColorString input) => BasicBackground (BasicColor.DarkBlue, input);
        public static ColorString BgBlue (this string input) => BasicBackground (BasicColor.Blue, input);
        public static ColorString BgBlue (this ColorString input) => BasicBackground (BasicColor.Blue, input);
        public static ColorString BgGreen (this string input) => BasicBackground (BasicColor.Green, input);
        public static ColorString BgGreen (this ColorString input) => BasicBackground (BasicColor.Green, input);
        public static ColorString BgDarkGreen (this string input) => BasicBackground (BasicColor.DarkGreen, input);
        public static ColorString BgDarkGreen (this ColorString input) => BasicBackground (BasicColor.DarkGreen, input);
        public static ColorString BgDarkYellow (this string input) => BasicBackground (BasicColor.DarkYellow, input);
        public static ColorString BgDarkYellow (this ColorString input) => BasicBackground (BasicColor.DarkYellow, input);
        public static ColorString BgYellow (this string input) => BasicBackground (BasicColor.Yellow, input);
        public static ColorString BgYellow (this ColorString input) => BasicBackground (BasicColor.Yellow, input);
        public static ColorString BgGrey (this string input) => BasicBackground (BasicColor.Grey, input);
        public static ColorString BgGrey (this ColorString input) => BasicBackground (BasicColor.Grey, input);
        public static ColorString BgDarkGrey (this string input) => BasicBackground (BasicColor.DarkGrey, input);
        public static ColorString BgDarkGrey (this ColorString input) => BasicBackground (BasicColor.DarkGrey, input);
        public static ColorString BgBlack (this string input) => BasicBackground (BasicColor.Black, input);
        public static ColorString BgBlack (this ColorString input) => BasicBackground (BasicColor.Black, input);
        private static ColorString BasicForeground (BasicColor color, string input) => BasicForeground (color, (ColorString) input);
        private static ColorString BasicForeground (BasicColor color, ColorString input) => input.WithForeground (color);
        private static ColorString BasicBackground (BasicColor color, string input) => BasicBackground (color, ((ColorString) input));
        private static ColorString BasicBackground (BasicColor color, ColorString input) => input.WithBackground (color);
    }
}