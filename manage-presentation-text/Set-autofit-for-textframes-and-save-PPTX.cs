using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            var slide = presentation.Slides[0];

            // Add a rectangle auto shape
            var autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 30, 30, 350, 100);

            // Add a text frame with sample text
            autoShape.AddTextFrame("Sample text for autofit demonstration");

            // Configure the autofit behavior of the text frame
            var textFrameFormat = autoShape.TextFrame.TextFrameFormat;
            textFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;

            // Save the modified presentation
            presentation.Save("AutofitOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}