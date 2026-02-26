using System;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputImagePath = "slide1.png";
        string outputPresentationPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Create a collection of fallback font rules
        Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();
        // Add a rule that maps a Unicode range to a fallback font
        rules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

        // Assign the fallback rules to the presentation's FontsManager
        pres.FontsManager.FontFallBackRulesCollection = rules;

        // Render the first slide to an image
        Aspose.Slides.IImage image = pres.Slides[0].GetImage(1f, 1f);
        // Save the rendered image as PNG
        image.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
        image.Dispose();

        // Save the presentation (required before exiting)
        pres.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}