using System;
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
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 100);

        // Add a text frame with sample text
        shape.AddTextFrame("Rotated Text");

        // Access the text frame and its format
        Aspose.Slides.ITextFrame textFrame = shape.TextFrame;
        Aspose.Slides.ITextFrameFormat format = textFrame.TextFrameFormat;

        // Set custom rotation angle for the text within the frame (e.g., -45 degrees)
        format.RotationAngle = -45f;

        // Optionally rotate the shape itself (e.g., 30 degrees)
        shape.Rotation = 30f;

        // Save the presentation
        presentation.Save("CustomTextRotation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}