using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string imagePath = "slide1.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Create fallback rules collection and add a rule for Times New Roman
            Aspose.Slides.IFontFallBackRulesCollection fallbackRules = new Aspose.Slides.FontFallBackRulesCollection();
            fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
            presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

            // Render the first slide to trigger fallback rendering
            Aspose.Slides.IImage slideImage = presentation.Slides[0].GetImage(1f, 1f);
            slideImage.Save(imagePath, Aspose.Slides.ImageFormat.Png);

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Verify that fallback fonts are not embedded in the saved file
            Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
            bool fallbackEmbedded = false;
            foreach (Aspose.Slides.IFontData fontData in embeddedFonts)
            {
                if (fontData.FontName.Equals("Times New Roman", StringComparison.OrdinalIgnoreCase))
                {
                    fallbackEmbedded = true;
                    break;
                }
            }

            if (fallbackEmbedded)
            {
                Console.WriteLine("Fallback font was embedded, which is unexpected.");
            }
            else
            {
                Console.WriteLine("Fallback font is not embedded as expected.");
            }

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}