using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input, output and network font folder
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string networkFontFolder = @"\\networkshare\fonts";

        // Verify that the input presentation exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load external fonts from the network share (fallback fonts source)
        try
        {
            Aspose.Slides.FontsLoader.LoadExternalFonts(new string[] { networkFontFolder });
        }
        catch (Exception ex)
        {
            // Handle network or access errors while loading fonts
            Console.WriteLine("Failed to load external fonts: " + ex.Message);
            // Continue without external fonts
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Create a fallback rule for a Unicode range (e.g., Emoji)
            Aspose.Slides.IFontFallBackRule fallbackRule = new Aspose.Slides.FontFallBackRule(0x1F600, 0x1F64F, "Segoe UI Emoji");
            // Add additional fallback fonts to the rule
            fallbackRule.AddFallBackFonts("Arial Unicode MS");
            fallbackRule.AddFallBackFonts(new string[] { "Noto Color Emoji", "Segoe UI Symbol" });

            // Retrieve the existing fallback rules collection
            Aspose.Slides.IFontFallBackRulesCollection rules = pres.FontsManager.FontFallBackRulesCollection;
            // Add the new rule to the collection
            rules.Add(fallbackRule);
            // Assign the updated collection back to the FontsManager
            pres.FontsManager.FontFallBackRulesCollection = rules;

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format or processing issues
            // format not supported
            Console.WriteLine("Error processing presentation: " + ex.Message);
        }
        finally
        {
            // Clear the font cache after processing
            Aspose.Slides.FontsLoader.ClearCache();
        }
    }
}