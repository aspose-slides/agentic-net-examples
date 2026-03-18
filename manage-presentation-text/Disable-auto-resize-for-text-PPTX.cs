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

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

            // Add a text frame with initial text
            autoShape.AddTextFrame("Initial text");

            // Disable automatic text autofit (no resizing of text or shape)
            Aspose.Slides.ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
            textFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.None;

            // Append more text to demonstrate that the shape does not resize automatically
            autoShape.TextFrame.Paragraphs[0].Portions[0].Text +=
                " - additional content that would normally cause resizing.";

            // Save the presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Output any errors that occur
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}