using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 100);

        // Add a text frame with sample text
        shape.AddTextFrame("Sample text");

        // Disable autofit for the text frame
        shape.TextFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.None;

        // Define output file path
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "DisableAutofit.pptx");

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}