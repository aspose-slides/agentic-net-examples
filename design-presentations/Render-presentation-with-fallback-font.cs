using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths
            string inputPath = "input.pptx";
            string outputImagePath = "slide0.png";
            string outputPresentationPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Get the fallback rules collection
            Aspose.Slides.IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

            // Add a fallback rule for Unicode range 0x400-0x4FF to use Times New Roman
            fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

            // Assign the updated collection back to the FontsManager
            presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

            // Render the first slide to an image
            Aspose.Slides.IImage slideImage = presentation.Slides[0].GetImage(1f, 1f);
            slideImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);

            // Save the presentation
            presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}