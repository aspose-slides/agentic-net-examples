using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first (default) slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,
            100,   // X position
            100,   // Y position
            200,   // Width
            100    // Height
        );

        // Define a scaling factor
        float scaleFactor = 1.5f;

        // Scale the shape's width and height
        shape.Width = shape.Width * scaleFactor;
        shape.Height = shape.Height * scaleFactor;

        // Save the presentation
        presentation.Save("ScaledShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}