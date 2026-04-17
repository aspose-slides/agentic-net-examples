using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";
        var imagePath = "slide.png";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Define fallback rule (e.g., for Cyrillic range) to use Times New Roman
            var fallbackRules = new Aspose.Slides.FontFallBackRulesCollection();
            fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
            presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

            // Render first slide to trigger fallback rendering
            var image = presentation.Slides[0].GetImage(1f, 1f);
            image.Save(imagePath, Aspose.Slides.ImageFormat.Png);

            // Save presentation (should not embed fallback fonts)
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Verify that fallback font is not embedded
            var embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
            var fallbackEmbedded = false;
            foreach (var font in embeddedFonts)
            {
                if (font.FontName.Equals("Times New Roman", StringComparison.OrdinalIgnoreCase))
                {
                    fallbackEmbedded = true;
                    break;
                }
            }

            Console.WriteLine(fallbackEmbedded
                ? "Fallback font was embedded."
                : "Fallback font not embedded.");

            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}