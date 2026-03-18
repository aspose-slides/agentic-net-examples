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

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 200);

            // Add a text frame to the shape
            Aspose.Slides.ITextFrame textFrame = shape.AddTextFrame("Sample text");

            // Set vertical anchoring type (e.g., Center)
            Aspose.Slides.ITextFrameFormat textFrameFormat = textFrame.TextFrameFormat;
            textFrameFormat.AnchoringType = Aspose.Slides.TextAnchorType.Center;

            // Save the presentation
            presentation.Save("AnchoringExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}