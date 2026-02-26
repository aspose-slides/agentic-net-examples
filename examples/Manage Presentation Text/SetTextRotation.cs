using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 100);

        // Add a text frame with initial text
        shape.AddTextFrame("Rotated Text");

        // Get the text frame and its format
        Aspose.Slides.ITextFrame textFrame = shape.TextFrame;
        Aspose.Slides.ITextFrameFormat textFormat = textFrame.TextFrameFormat;

        // Set the custom rotation angle for the text (in degrees)
        textFormat.RotationAngle = 45f;

        // Save the presentation as PPTX
        presentation.Save("RotatedText.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}