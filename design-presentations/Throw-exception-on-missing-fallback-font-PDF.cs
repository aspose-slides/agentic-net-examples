using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input presentation, fallback font, and output presentation
        string presentationPath = "input.pptx";
        string fallbackFontPath = "fallback.ttf";
        string outputPath = "output.pptx";

        // Verify that the input presentation exists
        if (!File.Exists(presentationPath))
        {
            Console.WriteLine("Presentation file not found: " + presentationPath);
            return;
        }

        // Attempt to load the fallback font if the file exists
        if (!File.Exists(fallbackFontPath))
        {
            Console.WriteLine("Fallback font file not found: " + fallbackFontPath);
            // Continue without loading the fallback font
        }
        else
        {
            try
            {
                byte[] fontData = File.ReadAllBytes(fallbackFontPath);
                Aspose.Slides.FontsLoader.LoadExternalFont(fontData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading fallback font: " + ex.Message);
            }
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath);

            // Create a new fallback rules collection
            Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();

            // Add a fallback rule (example: Cyrillic range falls back to Times New Roman)
            rules.Add(new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, "Times New Roman"));

            // Assign the rules collection to the FontsManager
            presentation.FontsManager.FontFallBackRulesCollection = rules;

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error processing presentation: " + ex.Message);
        }
    }
}