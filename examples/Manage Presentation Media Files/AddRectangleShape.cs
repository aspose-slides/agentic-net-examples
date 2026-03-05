using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape to the slide
        Aspose.Slides.IAutoShape rectangle = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, // Shape type
            50f,   // X position (points)
            150f,  // Y position (points)
            300f,  // Width (points)
            200f   // Height (points)
        );

        // Save the presentation in PPTX format
        presentation.Save("RectangleShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}