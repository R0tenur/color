using System.Globalization;

namespace Color
{
    /// <summary>
    /// Converts hex code to RGB tuple
    /// </summary>
    public interface IHexToRgbConverter
    {
        /// <summary>
        /// Converts hex code to RGB tuple
        /// </summary>
        /// <param name="hexCode">Hex code that starts with #</param>
        /// <returns>R, G, B tuple</returns>
        (int Red, int Green, int Blue) HexToRgb(string hexCode);

        /// <summary>
        /// Converts RGB to hex string
        /// </summary>
        /// <param name="Red"></param>
        /// <param name="Green"></param>
        /// <param name="Blue"></param>
        /// <returns>Returns hex string</returns>
        string RgbToHex(int red, int green, int blue);
    }
    ///<inheritdoc/>
    public class HexToRgbConverter : IHexToRgbConverter
    {
        ///<inheritdoc/>
        public (int Red, int Green, int Blue) HexToRgb(string hexCode)
        {
            var bigint = int.Parse(hexCode.Substring(1), NumberStyles.HexNumber);
            var r = (bigint >> 16) & 255;
            var g = (bigint >> 8) & 255;
            var b = bigint & 255;
            return (r, g, b);
        }
        
        ///<inheritdoc/>
        public string RgbToHex(int red, int green, int blue)
        {
            string IntToHex(int input)
            {
                var hex = input.ToString("x");
                return hex.Length == 1 ? "0" + hex : hex;
            }

            return "#" + IntToHex(red) + IntToHex(green) + IntToHex(blue);
        }
    }
}