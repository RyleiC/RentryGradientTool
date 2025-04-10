using RentryGradientTool.Colors;

namespace RentryGradientTool;
/*
 * Written by Rylei C. on 9-4-2025
 * 
 * Purpose: Creates gradients for Rentry.co because those are a pain to make manually. Hope this comes of use for you!
 */

public class Program
{
    public static void Main()
    {
        string[] colors =
        [
            "FF0000", //Red
            "FF8800", //Orange
            "FFFF00", //Yellow
            "00FF00", //Green
            "00FF88", //Teal
            "00FFFF", //Cyan
            "0000FF", //Blue
            "8800FF", //Purple
            "FF00FF" //Mangenta
        ];

        Console.WriteLine(GradientMaker.ColorizeText("Rylei was here! This is a bunch of text so that you can admire this rainbow! You can use this tool to beautify your profile!", colors));
    }
}