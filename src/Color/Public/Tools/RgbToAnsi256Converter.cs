using System.Collections.Generic;

namespace Color
{
    /// <summary>
    /// Converts rgb code to the closest ansi256 color
    /// </summary>
    public interface IRgbToAnsi256Converter
    {
        Ansi256Color GetClosest((int red, int green, int blue) input);
    }

    /// </inheritdocs>
    public class RgbToAnsi256Converter : IRgbToAnsi256Converter
    {
        private readonly IColorDistance _distanceFinder;
        public RgbToAnsi256Converter(IColorDistance distanceFinder)
        {
            _distanceFinder = distanceFinder;
        }
        public RgbToAnsi256Converter()
        {
            _distanceFinder = new ColorDistance(new HexToRgbConverter());
        }
        private readonly Dictionary<Ansi256Color, (int Red, int Green, int blue)> Dic = new()
        {
            { Ansi256Color.Black, (0, 0, 0) },
            { Ansi256Color.Maroon, (128, 0, 0) },
            { Ansi256Color.Green, (0, 128, 0) },
            { Ansi256Color.Olive, (128, 128, 0) },
            { Ansi256Color.Navy, (0, 0, 128) },
            { Ansi256Color.Purple, (128, 0, 128) },
            { Ansi256Color.Teal, (0, 128, 128) },
            { Ansi256Color.Silver, (192, 192, 192) },
            { Ansi256Color.Grey, (128, 128, 128) },
            { Ansi256Color.Red, (255, 0, 0) },
            { Ansi256Color.Lime, (0, 255, 0) },
            { Ansi256Color.Yellow, (255, 255, 0) },
            { Ansi256Color.Blue, (0, 0, 255) },
            { Ansi256Color.Fuchsia, (255, 0, 255) },
            { Ansi256Color.Aqua, (0, 255, 255) },
            { Ansi256Color.White, (255, 255, 255) },
            { Ansi256Color.Grey0, (0, 0, 0) },
            { Ansi256Color.NavyBlue, (0, 0, 95) },
            { Ansi256Color.DarkBlue, (0, 0, 135) },
            { Ansi256Color.Blue3, (0, 0, 175) },
            { Ansi256Color.Blue3_2, (0, 0, 215) },
            { Ansi256Color.Blue1, (0, 0, 255) },
            { Ansi256Color.DarkGreen, (0, 95, 0) },
            { Ansi256Color.DeepSkyBlue4, (0, 95, 95) },
            { Ansi256Color.DeepSkyBlue4_1, (0, 95, 135) },
            { Ansi256Color.DeepSkyBlue4_2, (0, 95, 175) },
            { Ansi256Color.DodgerBlue3, (0, 95, 215) },
            { Ansi256Color.DodgerBlue2, (0, 95, 255) },
            { Ansi256Color.Green4, (0, 135, 0) },
            { Ansi256Color.SpringGreen4, (0, 135, 95) },
            { Ansi256Color.Turquoise4, (0, 135, 135) },
            { Ansi256Color.DeepSkyBlue3, (0, 135, 175) },
            { Ansi256Color.DeepSkyBlue3_2, (0, 135, 215) },
            { Ansi256Color.DodgerBlue1, (0, 135, 255) },
            { Ansi256Color.Green3_2, (0, 175, 0) },
            { Ansi256Color.SpringGreen3, (0, 175, 95) },
            { Ansi256Color.DarkCyan, (0, 175, 135) },
            { Ansi256Color.LightSeaGreen, (0, 175, 175) },
            { Ansi256Color.DeepSkyBlue2, (0, 175, 215) },
            { Ansi256Color.DeepSkyBlue1, (0, 175, 255) },
            { Ansi256Color.Green3_3, (0, 215, 0) },
            { Ansi256Color.SpringGreen3_1, (0, 215, 95) },
            { Ansi256Color.SpringGreen2, (0, 215, 135) },
            { Ansi256Color.Cyan3, (0, 215, 175) },
            { Ansi256Color.DarkTurquoise, (0, 215, 215) },
            { Ansi256Color.Turquoise2, (0, 215, 255) },
            { Ansi256Color.Green1, (0, 255, 0) },
            { Ansi256Color.SpringGreen2_1, (0, 255, 95) },
            { Ansi256Color.SpringGreen1, (0, 255, 135) },
            { Ansi256Color.MediumSpringGreen, (0, 255, 175) },
            { Ansi256Color.Cyan2, (0, 255, 215) },
            { Ansi256Color.Cyan1, (0, 255, 255) },
            { Ansi256Color.DarkRed, (95, 0, 0) },
            { Ansi256Color.DeepPink4, (95, 0, 95) },
            { Ansi256Color.Purple4, (95, 0, 135) },
            { Ansi256Color.Purple4_1, (95, 0, 175) },
            { Ansi256Color.Purple3, (95, 0, 215) },
            { Ansi256Color.BlueViolet, (95, 0, 255) },
            { Ansi256Color.Orange4, (95, 95, 0) },
            { Ansi256Color.Grey37, (95, 95, 95) },
            { Ansi256Color.MediumPurple4, (95, 95, 135) },
            { Ansi256Color.SlateBlue3, (95, 95, 175) },
            { Ansi256Color.SlateBlue3_1, (95, 95, 215) },
            { Ansi256Color.RoyalBlue1, (95, 95, 255) },
            { Ansi256Color.Chartreuse4, (95, 135, 0) },
            { Ansi256Color.DarkSeaGreen4, (95, 135, 95) },
            { Ansi256Color.PaleTurquoise4, (95, 135, 135) },
            { Ansi256Color.SteelBlue, (95, 135, 175) },
            { Ansi256Color.SteelBlue3, (95, 135, 215) },
            { Ansi256Color.CornflowerBlue, (95, 135, 255) },
            { Ansi256Color.Chartreuse3, (95, 175, 0) },
            { Ansi256Color.DarkSeaGreen4_1, (95, 175, 95) },
            { Ansi256Color.CadetBlue, (95, 175, 135) },
            { Ansi256Color.CadetBlue_1, (95, 175, 175) },
            { Ansi256Color.SkyBlue3, (95, 175, 215) },
            { Ansi256Color.SteelBlue1, (95, 175, 255) },
            { Ansi256Color.Chartreuse3_1, (95, 215, 0) },
            { Ansi256Color.PaleGreen3, (95, 215, 95) },
            { Ansi256Color.SeaGreen3, (95, 215, 135) },
            { Ansi256Color.Aquamarine3, (95, 215, 175) },
            { Ansi256Color.MediumTurquoise, (95, 215, 215) },
            { Ansi256Color.SteelBlue1_1, (95, 215, 255) },
            { Ansi256Color.Chartreuse2, (95, 255, 0) },
            { Ansi256Color.SeaGreen2, (95, 255, 95) },
            { Ansi256Color.SeaGreen1, (95, 255, 135) },
            { Ansi256Color.SeaGreen1_1, (95, 255, 175) },
            { Ansi256Color.Aquamarine1, (95, 255, 215) },
            { Ansi256Color.DarkSlateGray2, (95, 255, 255) },
            { Ansi256Color.DarkRed_1, (135, 0, 0) },
            { Ansi256Color.DeepPink4_1, (135, 0, 95) },
            { Ansi256Color.DarkMagenta, (135, 0, 135) },
            { Ansi256Color.DarkMagenta_1, (135, 0, 175) },
            { Ansi256Color.DarkViolet, (135, 0, 215) },
            { Ansi256Color.Purple_1, (135, 0, 255) },
            { Ansi256Color.Orange4_1, (135, 95, 0) },
            { Ansi256Color.LightPink4, (135, 95, 95) },
            { Ansi256Color.Plum4, (135, 95, 135) },
            { Ansi256Color.MediumPurple3, (135, 95, 175) },
            { Ansi256Color.MediumPurple3_1, (135, 95, 215) },
            { Ansi256Color.SlateBlue1, (135, 95, 255) },
            { Ansi256Color.Yellow4, (135, 135, 0) },
            { Ansi256Color.Wheat4, (135, 135, 95) },
            { Ansi256Color.Grey53, (135, 135, 135) },
            { Ansi256Color.LightSlateGrey, (135, 135, 175) },
            { Ansi256Color.MediumPurple, (135, 135, 215) },
            { Ansi256Color.LightSlateBlue, (135, 135, 255) },
            { Ansi256Color.Yellow4_1, (135, 175, 0) },
            { Ansi256Color.DarkOliveGreen3, (135, 175, 95) },
            { Ansi256Color.DarkSeaGreen, (135, 175, 135) },
            { Ansi256Color.LightSkyBlue3, (135, 175, 175) },
            { Ansi256Color.LightSkyBlue3_1, (135, 175, 215) },
            { Ansi256Color.SkyBlue2, (135, 175, 255) },
            { Ansi256Color.Chartreuse2_1, (135, 215, 0) },
            { Ansi256Color.DarkOliveGreen3_1, (135, 215, 95) },
            { Ansi256Color.PaleGreen3_1, (135, 215, 135) },
            { Ansi256Color.DarkSeaGreen3, (135, 215, 175) },
            { Ansi256Color.DarkSlateGray3, (135, 215, 215) },
            { Ansi256Color.SkyBlue1, (135, 215, 255) },
            { Ansi256Color.Chartreuse1, (135, 255, 0) },
            { Ansi256Color.LightGreen, (135, 255, 95) },
            { Ansi256Color.LightGreen_1, (135, 255, 135) },
            { Ansi256Color.PaleGreen1, (135, 255, 175) },
            { Ansi256Color.Aquamarine1_1, (135, 255, 215) },
            { Ansi256Color.DarkSlateGray1, (135, 255, 255) },
            { Ansi256Color.Red3, (175, 0, 0) },
            { Ansi256Color.DeepPink4_2, (175, 0, 95) },
            { Ansi256Color.MediumVioletRed, (175, 0, 135) },
            { Ansi256Color.Magenta3, (175, 0, 175) },
            { Ansi256Color.DarkViolet_1, (175, 0, 215) },
            { Ansi256Color.Purple_2, (175, 0, 255) },
            { Ansi256Color.DarkOrange3, (175, 95, 0) },
            { Ansi256Color.IndianRed, (175, 95, 95) },
            { Ansi256Color.HotPink3, (175, 95, 135) },
            { Ansi256Color.MediumOrchid3, (175, 95, 175) },
            { Ansi256Color.MediumOrchid, (175, 95, 215) },
            { Ansi256Color.MediumPurple2, (175, 95, 255) },
            { Ansi256Color.DarkGoldenrod, (175, 135, 0) },
            { Ansi256Color.LightSalmon3, (175, 135, 95) },
            { Ansi256Color.RosyBrown, (175, 135, 135) },
            { Ansi256Color.Grey63, (175, 135, 175) },
            { Ansi256Color.MediumPurple2_1, (175, 135, 215) },
            { Ansi256Color.MediumPurple1, (175, 135, 255) },
            { Ansi256Color.Gold3, (175, 175, 0) },
            { Ansi256Color.DarkKhaki, (175, 175, 95) },
            { Ansi256Color.NavajoWhite3, (175, 175, 135) },
            { Ansi256Color.Grey69, (175, 175, 175) },
            { Ansi256Color.LightSteelBlue3, (175, 175, 215) },
            { Ansi256Color.LightSteelBlue, (175, 175, 255) },
            { Ansi256Color.Yellow3, (175, 215, 0) },
            { Ansi256Color.DarkOliveGreen3_2, (175, 215, 95) },
            { Ansi256Color.DarkSeaGreen3_2, (175, 215, 135) },
            { Ansi256Color.DarkSeaGreen2, (175, 215, 175) },
            { Ansi256Color.LightCyan3, (175, 215, 215) },
            { Ansi256Color.LightSkyBlue1, (175, 215, 255) },
            { Ansi256Color.GreenYellow, (175, 255, 0) },
            { Ansi256Color.DarkOliveGreen2, (175, 255, 95) },
            { Ansi256Color.PaleGreen1_1, (175, 255, 135) },
            { Ansi256Color.DarkSeaGreen2_1, (175, 255, 175) },
            { Ansi256Color.DarkSeaGreen1, (175, 255, 215) },
            { Ansi256Color.PaleTurquoise1, (175, 255, 255) },
            { Ansi256Color.Red3_1, (215, 0, 0) },
            { Ansi256Color.DeepPink3, (215, 0, 95) },
            { Ansi256Color.DeepPink3_1, (215, 0, 135) },
            { Ansi256Color.Magenta3_1, (215, 0, 175) },
            { Ansi256Color.Magenta3_2, (215, 0, 215) },
            { Ansi256Color.Magenta2, (215, 0, 255) },
            { Ansi256Color.DarkOrange3_1, (215, 95, 0) },
            { Ansi256Color.IndianRed_1, (215, 95, 95) },
            { Ansi256Color.HotPink3_1, (215, 95, 135) },
            { Ansi256Color.HotPink2, (215, 95, 175) },
            { Ansi256Color.Orchid, (215, 95, 215) },
            { Ansi256Color.MediumOrchid1, (215, 95, 255) },
            { Ansi256Color.Orange3, (215, 135, 0) },
            { Ansi256Color.LightSalmon3_1, (215, 135, 95) },
            { Ansi256Color.LightPink3, (215, 135, 135) },
            { Ansi256Color.Pink3, (215, 135, 175) },
            { Ansi256Color.Plum3, (215, 135, 215) },
            { Ansi256Color.Violet, (215, 135, 255) },
            { Ansi256Color.Gold3_1, (215, 175, 0) },
            { Ansi256Color.LightGoldenrod3, (215, 175, 95) },
            { Ansi256Color.Tan, (215, 175, 135) },
            { Ansi256Color.MistyRose3, (215, 175, 175) },
            { Ansi256Color.Thistle3, (215, 175, 215) },
            { Ansi256Color.Plum2, (215, 175, 255) },
            { Ansi256Color.Yellow3_1, (215, 215, 0) },
            { Ansi256Color.Khaki3, (215, 215, 95) },
            { Ansi256Color.LightGoldenrod2, (215, 215, 135) },
            { Ansi256Color.LightYellow3, (215, 215, 175) },
            { Ansi256Color.Grey84, (215, 215, 215) },
            { Ansi256Color.LightSteelBlue1, (215, 215, 255) },
            { Ansi256Color.Yellow2, (215, 255, 0) },
            { Ansi256Color.DarkOliveGreen1, (215, 255, 95) },
            { Ansi256Color.DarkOliveGreen1_1, (215, 255, 135) },
            { Ansi256Color.DarkSeaGreen1_1, (215, 255, 175) },
            { Ansi256Color.Honeydew2, (215, 255, 215) },
            { Ansi256Color.LightCyan1, (215, 255, 255) },
            { Ansi256Color.Red1, (255, 0, 0) },
            { Ansi256Color.DeepPink2, (255, 0, 95) },
            { Ansi256Color.DeepPink1, (255, 0, 135) },
            { Ansi256Color.DeepPink1_1, (255, 0, 175) },
            { Ansi256Color.Magenta2_1, (255, 0, 215) },
            { Ansi256Color.Magenta1, (255, 0, 255) },
            { Ansi256Color.OrangeRed1, (255, 95, 0) },
            { Ansi256Color.IndianRed1, (255, 95, 95) },
            { Ansi256Color.IndianRed1_2, (255, 95, 135) },
            { Ansi256Color.HotPink, (255, 95, 175) },
            { Ansi256Color.HotPink_2, (255, 95, 215) },
            { Ansi256Color.MediumOrchid1_1, (255, 95, 255) },
            { Ansi256Color.DarkOrange, (255, 135, 0) },
            { Ansi256Color.Salmon1, (255, 135, 95) },
            { Ansi256Color.LightCoral, (255, 135, 135) },
            { Ansi256Color.PaleVioletRed1, (255, 135, 175) },
            { Ansi256Color.Orchid2, (255, 135, 215) },
            { Ansi256Color.Orchid1, (255, 135, 255) },
            { Ansi256Color.Orange1, (255, 175, 0) },
            { Ansi256Color.SandyBrown, (255, 175, 95) },
            { Ansi256Color.LightSalmon1, (255, 175, 135) },
            { Ansi256Color.LightPink1, (255, 175, 175) },
            { Ansi256Color.Pink1, (255, 175, 215) },
            { Ansi256Color.Plum1, (255, 175, 255) },
            { Ansi256Color.Gold1, (255, 215, 0) },
            { Ansi256Color.LightGoldenrod2_1, (255, 215, 95) },
            { Ansi256Color.LightGoldenrod2_2, (255, 215, 135) },
            { Ansi256Color.NavajoWhite1, (255, 215, 175) },
            { Ansi256Color.MistyRose1, (255, 215, 215) },
            { Ansi256Color.Thistle1, (255, 215, 255) },
            { Ansi256Color.Yellow1, (255, 255, 0) },
            { Ansi256Color.LightGoldenrod1, (255, 255, 95) },
            { Ansi256Color.Khaki1, (255, 255, 135) },
            { Ansi256Color.Wheat1, (255, 255, 175) },
            { Ansi256Color.Cornsilk1, (255, 255, 215) },
            { Ansi256Color.Grey100, (255, 255, 255) },
            { Ansi256Color.Grey3, (8, 8, 8) },
            { Ansi256Color.Grey7, (18, 18, 18) },
            { Ansi256Color.Grey11, (28, 28, 28) },
            { Ansi256Color.Grey15, (38, 38, 38) },
            { Ansi256Color.Grey19, (48, 48, 48) },
            { Ansi256Color.Grey23, (58, 58, 58) },
            { Ansi256Color.Grey27, (68, 68, 68) },
            { Ansi256Color.Grey30, (78, 78, 78) },
            { Ansi256Color.Grey35, (88, 88, 88) },
            { Ansi256Color.Grey39, (98, 98, 98) },
            { Ansi256Color.Grey42, (108, 108, 108) },
            { Ansi256Color.Grey46, (118, 118, 118) },
            { Ansi256Color.Grey50, (128, 128, 128) },
            { Ansi256Color.Grey54, (138, 138, 138) },
            { Ansi256Color.Grey58, (148, 148, 148) },
            { Ansi256Color.Grey62, (158, 158, 158) },
            { Ansi256Color.Grey66, (168, 168, 168) },
            { Ansi256Color.Grey70, (178, 178, 178) },
            { Ansi256Color.Grey74, (188, 188, 188) },
            { Ansi256Color.Grey78, (198, 198, 198) },
            { Ansi256Color.Grey82, (208, 208, 208) },
            { Ansi256Color.Grey85, (218, 218, 218) },
            { Ansi256Color.Grey89, (228, 228, 228) },
            { Ansi256Color.Grey93, (238, 238, 238) }
        };

        private static Dictionary<(int Red, int Green, int Blue), Ansi256Color> CachedColors = new();

        public Ansi256Color GetClosest((int red, int green, int blue) input)
        {
            if (CachedColors.TryGetValue(input, out var cachedColor))
            {
                return cachedColor;
            }

            double smallest = -1;
            var color = Ansi256Color.White;
            foreach (var item in Dic)
            {
                var value = _distanceFinder.GetDistance(input, item.Value);

                if (smallest == -1)
                {
                    smallest = value;
                    color = item.Key;
                    continue;
                }

                if (value < smallest)
                {
                    smallest = value;
                    color = item.Key;
                }

                if(smallest == 0) {
                    break;
                }
            }
            CachedColors.Add(input, color);
            return color;
        }
    }
}