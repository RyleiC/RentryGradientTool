using System.Drawing;
using System.Globalization;

namespace RentryGradientTool.Colors
{
    public struct HexColor
    {
        private const int HexidecimalStride = 2;

        public byte R { get; init; }
        public byte G { get; init; }
        public byte B { get; init; }

        public HexColor(string hexCode)
        {
            hexCode = hexCode.Trim('#');

            R = byte.Parse
            (
                s: hexCode.AsSpan(HexidecimalStride * 0, HexidecimalStride),
                style: NumberStyles.HexNumber
            );

            G = byte.Parse
            (
                s: hexCode.AsSpan(HexidecimalStride * 1, HexidecimalStride),
                style: NumberStyles.HexNumber
            );

            B = byte.Parse
            (
                s: hexCode.AsSpan(HexidecimalStride * 2, HexidecimalStride),
                style: NumberStyles.HexNumber
            );
        }

        public HexColor(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public HexColor(Color color) : this(color.R, color.G, color.B) { }

        public override string ToString()
        {
            return $"#{R:X2}{G:X2}{B:X2}";
        }
    }
}
