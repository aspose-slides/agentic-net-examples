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
            50,    // X position (points)
            150,   // Y position (points)
            300,   // Width (points)
            200    // Height (points)
        );

        // Save the presentation to a PPTX file
        presentation.Save("MediaPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}