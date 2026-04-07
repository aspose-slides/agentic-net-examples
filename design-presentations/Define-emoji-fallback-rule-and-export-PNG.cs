using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputImagePath = "slide0.png";
        string outputPresentationPath = "output_with_fallback.pptx";

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Create fallback rules collection
            Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();

            // Example rule for basic Latin characters (optional)
            rules.Add(new Aspose.Slides.FontFallBackRule(0x0000, 0x00FF, "Arial"));

            // Emoji fallback rule using common emoji fonts
            string[] emojiFonts = new string[] { "Segoe UI Emoji", "Apple Color Emoji", "Noto Color Emoji" };
            rules.Add(new Aspose.Slides.FontFallBackRule(0x1F600, 0x1F64F, emojiFonts));

            // Load presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Assign fallback rules to the presentation
            pres.FontsManager.FontFallBackRulesCollection = rules;

            // Export first slide to PNG to verify rendering
            Aspose.Slides.IImage img = pres.Slides[0].GetImage(1f, 1f);
            img.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
            img.Dispose();

            // Save the presentation (required before exit)
            pres.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}