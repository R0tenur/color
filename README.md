# Color
## HexToRgbConverter
Converts hex to RGB and RGB to hex

Usage:

```c#
IHexToRgbConverter converter = new HexToRgbConverter();

(int Red, int Green, int blue) = converter.HexToRgb(#000000); // => (0, 0, 0)

var hexCode = converter.RgbToHex(0, 0, 0); // => #000000

```

## ColorDistance
Gets euclidean distance between colors

Usage:
```c#
IColorDistance distanceCalculator = new ColorDistance();

var color1 = (0, 0, 0);
var color2 =(255, 255, 255);
var distance = distanceCalculator.GetDistance(color1, color2);

// or
distance = distanceCalculator.GetDistance("#000000", "#ffffff");
```