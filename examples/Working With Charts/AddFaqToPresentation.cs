using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape to hold the FAQ text
        Aspose.Slides.IAutoShape faqShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 400);

        // Add a text frame with initial content
        Aspose.Slides.ITextFrame textFrame = faqShape.AddTextFrame("FAQ");

        // Set the FAQ content
        textFrame.Text = "Q1: How to use Aspose.Slides?\nA1: Refer to the documentation.\n\nQ2: How to add a chart?\nA2: Use slide.Shapes.AddChart(...);";

        // Save the presentation before exiting
        presentation.Save("FaqPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}