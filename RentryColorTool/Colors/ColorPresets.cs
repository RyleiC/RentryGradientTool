using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentryGradientTool.Colors
{
    public static class ColorPresets
    {
        public static readonly Color[] Rainbow =
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

        public static readonly Color[] Grayscale =
        [
            Color.Black,
            Color.DarkGray,
            Color.Gray,
            Color.LightGray,
            Color.White
        ];

        public static readonly Color[] Sunset =
        [
            Color.Magenta,
            Color.Yellow,
            Color.Cyan
        ];

        public static readonly Color[] Unpleasantness =
        [
            Color.Lime,
            Color.HotPink,
            Color.Sienna
        ];
    }
}
