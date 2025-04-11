using System.Drawing;

namespace RentryGradientTool.Colors
{
    public static class ColorPresets
    {
        public static Color[] Rainbow { get; } =
        [
            Color.Red,
            Color.OrangeRed,
            Color.Orange,
            Color.Yellow,
            Color.Lime,
            Color.LightGreen,
            Color.Cyan,
            Color.Blue,
            Color.Indigo,
            Color.Magenta
        ];

        public static Color[] Grayscale { get; } =
        [
            Color.Black,
            Color.DarkGray,
            Color.Gray,
            Color.LightGray,
            Color.White
        ];

        public static Color[] Sunset { get; } =
        [
            Color.Magenta,
            Color.Yellow,
            Color.Cyan
        ];

        public static Color[] Unpleasantness { get; }  =
        [
            Color.Lime,
            Color.HotPink,
            Color.Sienna
        ];
    }
}
