using System;
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

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

            // Add a text frame with sample text
            shape.AddTextFrame("This is a sample text that will be wrapped inside the text frame.");

            // Enable text wrapping inside the text frame
            shape.TextFrame.TextFrameFormat.WrapText = Aspose.Slides.NullableBool.True;

            // Save the presentation
            presentation.Save("WrappedText.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}