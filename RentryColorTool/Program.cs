using RentryGradientTool.Colors;
using System.Drawing;

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
        var text = "Rylei was here! This is a bunch of text so that you can admire this rainbow! You can use this tool to beautify your profile!";

        Console.WriteLine
        (
            value: GradientMaker.ColorizeText(text, ColorPresets.Rainbow)
        );
    }
}