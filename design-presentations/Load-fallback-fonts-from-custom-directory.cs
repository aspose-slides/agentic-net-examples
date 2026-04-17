using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputImagePath = "output.png";
        string outputPresentationPath = "output.pptx";
        string fontsDirectory = "custom_fonts";

        // Verify input presentation exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input presentation file does not exist.");
            return;
        }

        // Verify custom fonts directory exists
        if (!Directory.Exists(fontsDirectory))
        {
            Console.WriteLine("Custom fonts directory does not exist.");
            return;
        }

        // Load custom fonts from the specified directory
        try
        {
            string[] fontFolders = new string[] { fontsDirectory };
            Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading external fonts: " + ex.Message);
            // Continue without custom fonts if loading fails
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading presentation: " + ex.Message);
            // Format not supported
            // format not supported
            return;
        }

        // Create and assign font fallback rules
        Aspose.Slides.IFontFallBackRulesCollection fallbackRules = new Aspose.Slides.FontFallBackRulesCollection();
        // Example: fallback for Cyrillic range to "Arial"
        Aspose.Slides.FontFallBackRule cyrillicRule = new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, "Arial");
        fallbackRules.Add(cyrillicRule);
        presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

        // Render the first slide to an image
        try
        {
            Aspose.Slides.IImage slideImage = presentation.Slides[0].GetImage(1f, 1f);
            slideImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error rendering slide: " + ex.Message);
        }

        // Save the modified presentation
        try
        {
            presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }

        // Clear the font cache
        Aspose.Slides.FontsLoader.ClearCache();

        // Dispose the presentation
        if (presentation != null)
        {
            presentation.Dispose();
        }
    }
}