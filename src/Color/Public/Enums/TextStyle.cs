namespace Color
{
    public static class TextStyle
    {
        public static (int Open, int Close) Reset => (0, 0);
        public static (int Open, int Close) Bold => (1, 22);
        public static (int Open, int Close) Dim => (2, 22);
        public static (int Open, int Close) Italic => (3, 23);
        public static (int Open, int Close) Underline => (4, 24);
        public static (int Open, int Close) Overline => (53, 55);
        public static (int Open, int Close) Inverse => (7, 27);
        public static (int Open, int Close) Hidden => (8, 28);
        public static (int Open, int Close) StrikeThrough => (9, 29);
    }
}
