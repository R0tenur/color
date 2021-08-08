using System;

namespace Color
{
    /// <summary>
    /// Get's the distance between two colors based on <see href="https://en.wikipedia.org/wiki/Color_difference">Wikipedia</see>
    /// </summary>
    public interface IColorDistance
    {
        /// <summary>
        /// Gets the distance betweeen two colors
        /// </summary>
        /// <param name="from">Color by the rgb format, in tuple form of (int red, int green, int blue)</param>
        /// <param name="to">Color by the rgb format, in tuple form of (int red, int green, int blue)</param>
        /// <returns>The distance</returns>
        double GetDistance((int red, int green, int blue) from, (int red, int green, int blue) to);
        /// <summary>
        /// Gets the distance betweeen two colors
        /// </summary>
        /// <param name="from">Color by the hex format, starting with #</param>
        /// <param name="to">Color to get the distance to by the hex format, starting with #</param>
        /// <returns>The distance</returns>
        double GetDistance(string from, string to);
    }

    /// </inheritdoc>
    public class ColorDistance : IColorDistance
    {
        IHexToRgbConverter _hexToRgbConverter;
        internal ColorDistance(IHexToRgbConverter hexToRgbConverter)
        {
            _hexToRgbConverter = hexToRgbConverter;
        }
        public ColorDistance()
        {
            _hexToRgbConverter = new HexToRgbConverter();
        }
        /// </inheritdoc>
        public double GetDistance((int red, int green, int blue) from, (int red, int green, int blue) to)
        {
            return Math.Sqrt(
                2 * Math.Pow(from.red - to.red, 2) +
                4 * Math.Pow(from.green - to.green, 2) +
                3 * Math.Pow(from.blue - to.blue, 2)
            );
        }
        /// </inheritdoc>
        public double GetDistance(string from, string to)
        {
            return GetDistance(
                _hexToRgbConverter.HexToRgb(from),
                _hexToRgbConverter.HexToRgb(to)
            );
        }
    }
}