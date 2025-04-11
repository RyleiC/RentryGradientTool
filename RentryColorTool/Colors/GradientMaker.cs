using System.Text;
using System.Drawing;

namespace RentryGradientTool.Colors;

public static class GradientMaker
{

    public static string ColorizeText(string text, params Color[] colors)
    {
        var hexColors = GenerateGradient(colors, text.Length);
        return ColorizeText(text, hexColors);
    }

    public static string ColorizeText(string text, params string[] hexidecimalColors)
    {
        var colors = GenerateGradient(hexidecimalColors, text.Length);
        return ColorizeText(text, colors);
    }

    private static string ColorizeText(string text, List<HexColor> colors)
    {
        var output = new StringBuilder();

        float ratio = (float)text.Length / colors.Count;

        for (var i = 0; i < text.Length; i++)
        {
            if (char.IsWhiteSpace(text[i]))
            {
                output.Append(text[i]); //Rentry ignores coloring on whitespace.
                continue;
            }

            output.Append($"%{colors[(int)(i / ratio)]}%{text[i]}%%");
        }

        return output.ToString();
    }



    public static List<HexColor> GenerateGradient(string[] colorCodes, int amountOfSteps)
    {
        if (amountOfSteps < colorCodes.Length)
        {
            throw new ArgumentException("The number of steps must be greater than the number of colors.");
        }

        var colors = new List<HexColor>();

        for (var i = 0; i < colorCodes.Length - 1; i++)
        {
            var rightColor = new HexColor(colorCodes[i + 1]);
            var leftColor = new HexColor(colorCodes[i]);
            var range = GenerateGradient(leftColor, rightColor, amountOfSteps / colorCodes.Length);
            colors.AddRange(range);
        }

        colors.Add(new HexColor(colorCodes[^1]));

        return colors;
    }

    public static List<HexColor> GenerateGradient(Color[] colors, int amountOfSteps)
    {
        if (amountOfSteps < colors.Length)
        {
            throw new ArgumentException("The number of steps must be greater than the number of colors.");
        }

        var hexColors = new List<HexColor>();

        for (var i = 0; i < colors.Length - 1; i++)
        {
            var rightColor = new HexColor(colors[i + 1]);
            var leftColor = new HexColor(colors[i]);
            var range = GenerateGradient(leftColor, rightColor, amountOfSteps / colors.Length);
            hexColors.AddRange(range);
        }

        hexColors.Add(new HexColor(colors[^1]));

        return hexColors;
    }
    private static List<HexColor> GenerateGradient(HexColor colorLeft, HexColor colorRight, int amountOfSteps)
    {
        var colors = new List<HexColor>();

        var stepR = (byte)((colorRight.R - colorLeft.R) / amountOfSteps);
        var stepG = (byte)((colorRight.G - colorLeft.G) / amountOfSteps);
        var stepB = (byte)((colorRight.B - colorLeft.B) / amountOfSteps);

        if (stepR == 0 && stepG == 0 && stepB == 0)
        {
            throw new Exception("The step between colors has been truncated to 0 and cannot progress! Consider adding more colors!");
        }

        for (var i = 0; i < amountOfSteps; i++)
        {
            var color = new HexColor(
                    r: (byte)(colorLeft.R + (stepR * i)),
                    g: (byte)(colorLeft.G + (stepG * i)),
                    b: (byte)(colorLeft.B + (stepB * i))
            );
            colors.Add(color);
        }

        return colors;
    }
}