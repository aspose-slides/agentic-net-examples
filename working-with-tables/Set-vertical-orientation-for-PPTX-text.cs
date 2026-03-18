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

            // Add a rectangle auto shape to the slide
            var autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);

            // Add a text frame with sample text
            autoShape.AddTextFrame("Sample vertical text");

            // Access the text frame and its format
            var textFrame = autoShape.TextFrame;
            var textFrameFormat = textFrame.TextFrameFormat;

            // Set the vertical text orientation
            textFrameFormat.TextVerticalType = Aspose.Slides.TextVerticalType.Vertical;

            // Save the presentation to disk
            presentation.Save("VerticalText.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Output any errors that occur
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}