# Color
## HexToRgbConverter
Converts hex to RGB and RGB to hex

Usage:

```c#
IHexToRgbConverter converter = new HexToRgbConverter();

(int Red, int Green, int blue) = converter.HexToRgb(#000000); // => (0, 0, 0)

var hexCode = converter.RgbToHex(0, 0, 0); // => #000000

```