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

        // Add a rectangle shape to the slide
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 100);

        // Add a text frame with initial text
        Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame("Rotated Text");

        // Set the rotation angle of the text within the shape (e.g., 45 degrees)
        Aspose.Slides.ITextFrameFormat textFormat = textFrame.TextFrameFormat;
        textFormat.RotationAngle = 45f;

        // Save the presentation to disk
        presentation.Save("TextRotation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}