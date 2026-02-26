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
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50f, 50f, 200f, 100f);

        // Move the shape to new X and Y coordinates
        shape.X = 150f; // New X position
        shape.Y = 200f; // New Y position

        // Save the presentation
        presentation.Save("MovedShape_out.pptx", SaveFormat.Pptx);
    }
}