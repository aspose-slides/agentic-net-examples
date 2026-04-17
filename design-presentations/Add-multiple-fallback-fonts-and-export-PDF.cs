using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        try
        {
            Presentation pres = new Presentation(inputPath);

            // Get existing fallback rules collection
            IFontFallBackRulesCollection rules = pres.FontsManager.FontFallBackRulesCollection;

            // Create a new fallback rule for a Unicode range and add additional fallback fonts
            IFontFallBackRule newRule = new FontFallBackRule(0x1F600, 0x1F64F, "Segoe UI Emoji");
            newRule.AddFallBackFonts("Arial Unicode MS");
            newRule.AddFallBackFonts(new string[] { "Noto Color Emoji", "Apple Color Emoji" });

            // Add the new rule to the collection
            rules.Add(newRule);

            // Assign the updated collection back to the FontsManager
            pres.FontsManager.FontFallBackRulesCollection = rules;

            string outputPath = "output.pptx";
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle exceptions such as unsupported format
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}