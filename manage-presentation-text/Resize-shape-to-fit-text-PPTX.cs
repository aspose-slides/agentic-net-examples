using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 300, 100);

            // Add a text frame with sample text
            Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame(
                "This is a sample text that might need the shape to resize accordingly.");

            // Set the shape to autofit its text
            Aspose.Slides.ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
            textFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;

            // Save the presentation
            presentation.Save("AdjustedShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}