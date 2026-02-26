using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation
        string inputPath = "input.pptx";

        // Directory where PNG images will be saved
        string outputDirectory = "output";
        Directory.CreateDirectory(outputDirectory);

        // Create a collection of font fallback rules
        Aspose.Slides.IFontFallBackRulesCollection fallbackRules = new Aspose.Slides.FontFallBackRulesCollection();
        // Example rule: for Unicode range 0x400‑0x4FF use "Times New Roman"
        fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
        // Additional rules can be added here if needed

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Apply the fallback rules to the presentation's FontsManager
        presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

        // Render each slide to a PNG image
        for (int index = 0; index < presentation.Slides.Count; index++)
        {
            Aspose.Slides.IImage slideImage = presentation.Slides[index].GetImage(1f, 1f);
            string outputPath = Path.Combine(outputDirectory, $"slide_{index + 1}.png");
            slideImage.Save(outputPath, Aspose.Slides.ImageFormat.Png);
            slideImage.Dispose();
        }

        // Save the presentation before exiting (as required)
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}