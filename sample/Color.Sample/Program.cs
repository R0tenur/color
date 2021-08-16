using System;
using Color;

Console.WriteLine("Hello".Color("#b3b97e").Bold() + " World".Color("#ff0000").StrikeThrough());
Console.WriteLine($"What {"Is".Red().BgDarkGreen().Italic()} this? {"Dunno".Dim()} You?");