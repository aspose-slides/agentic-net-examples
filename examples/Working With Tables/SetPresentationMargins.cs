using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape to the slide
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,
            50f,   // X position
            50f,   // Y position
            400f,  // Width
            200f   // Height
        );

        // Add a text frame to the shape
        shape.AddTextFrame("Sample text");

        // Access the text frame and its format
        Aspose.Slides.ITextFrame textFrame = shape.TextFrame;
        Aspose.Slides.ITextFrameFormat textFrameFormat = textFrame.TextFrameFormat;

        // Set margins (in points)
        textFrameFormat.MarginTop = 10.0;
        textFrameFormat.MarginBottom = 10.0;
        textFrameFormat.MarginLeft = 15.0;
        textFrameFormat.MarginRight = 15.0;

        // Save the presentation
        presentation.Save("SetMarginsOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}