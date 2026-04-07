using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputWithFallback = "output_fallback.png";
        string outputAfterClear = "output_cleared.png";
        string savedPresentationPath = "saved_presentation.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Add a fallback rule
            Aspose.Slides.IFontFallBackRulesCollection fallbackRules = new Aspose.Slides.FontFallBackRulesCollection();
            fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
            presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

            // Render slide with fallback rule applied
            Aspose.Slides.IImage imageWithFallback = presentation.Slides[0].GetImage(1f, 1f);
            imageWithFallback.Save(outputWithFallback, Aspose.Slides.ImageFormat.Png);

            // Clear fallback rules to restore original rendering behavior
            presentation.FontsManager.FontFallBackRulesCollection = new Aspose.Slides.FontFallBackRulesCollection();

            // Render slide after clearing fallback rules
            Aspose.Slides.IImage imageAfterClear = presentation.Slides[0].GetImage(1f, 1f);
            imageAfterClear.Save(outputAfterClear, Aspose.Slides.ImageFormat.Png);

            // Save the presentation before exiting
            presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("Format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}