using System.Text;

namespace RentryGradientTool.Colors;

public static class GradientMaker
{

    public static string ColorizeText(string text, params string[] colorCodes)
    {
        var colors = GenerateGradient(colorCodes, text.Length);
        var output = new StringBuilder();

        float ratio = (float)text.Length / colors.Count;

        for (var i = 0; i < text.Length; i++)
        {
            if (text[i] == ' ')
            {
                output.Append(' '); //Rentry ignores coloring on spaces.
                continue;
            }

            output.Append($"%{colors[(int)(i / ratio)]}%{text[i]}%%");
        }

        return output.ToString();
    }

    private static List<HexColor> GenerateGradient(string leftColor, string rightColor, int amountOfSteps)
    {
        var colors = new List<HexColor>();
        var hexLeft = new HexColor(leftColor);
        var hexRight = new HexColor(rightColor);

        var stepR = (byte)((hexLeft.R - hexRight.R) / amountOfSteps);
        var stepG = (byte)((hexLeft.G - hexRight.G) / amountOfSteps);
        var stepB = (byte)((hexLeft.B - hexRight.B) / amountOfSteps);

        if (stepR == 0 && stepG == 0 && stepB == 0)
        {
            throw new Exception("The step between colors has been truncated to 0 and cannot progress! Consider adding more colors!");
        }

        for (var i = 0; i < amountOfSteps; i++)
        {
            var color = new HexColor(
                    r: (byte)(hexRight.R + (stepR * i)),
                    g: (byte)(hexRight.G + (stepG * i)),
                    b: (byte)(hexRight.B + (stepB * i))
            );
            colors.Add(color);
        }

        return colors;
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
            var leftColor = colorCodes[i + 1];
            var rightColor = colorCodes[i];
            var range = GenerateGradient(leftColor, rightColor, amountOfSteps / colorCodes.Length);
            colors.AddRange(range);
        }

        colors.Add(new HexColor(colorCodes[^1]));

        return colors;
    }
}