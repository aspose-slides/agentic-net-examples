using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a textbox with sample text
            Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            shape.AddTextFrame("Sample text with fallback font.");

            // Set up fallback font rule for a Unicode range
            Aspose.Slides.IFontFallBackRulesCollection fallbackRules = new Aspose.Slides.FontFallBackRulesCollection();
            fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
            presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

            // Render the first slide to an image
            Aspose.Slides.IImage slideImage = presentation.Slides[0].GetImage(1f, 1f);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "SlideImage.png");
            slideImage.Save(imagePath, Aspose.Slides.ImageFormat.Png);

            // Save the presentation
            string presPath = Path.Combine(Directory.GetCurrentDirectory(), "FallbackPresentation.pptx");
            presentation.Save(presPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}