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

        // Add a rectangle auto shape
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

        // Add a text frame to the shape
        Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame("Rotated Text");

        // Set custom rotation angle for the text within the text frame
        Aspose.Slides.ITextFrameFormat textFormat = textFrame.TextFrameFormat;
        textFormat.RotationAngle = 45f; // Rotate text 45 degrees

        // Save the presentation
        presentation.Save("CustomTextRotation.pptx", SaveFormat.Pptx);
    }
}