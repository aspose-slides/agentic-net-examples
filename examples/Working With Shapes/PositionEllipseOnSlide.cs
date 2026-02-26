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

        // Add an ellipse shape at position (100, 100) with width 200 and height 150
        Aspose.Slides.IAutoShape ellipse = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Ellipse,
            100,   // X coordinate
            100,   // Y coordinate
            200,   // Width
            150    // Height
        );

        // Save the presentation
        presentation.Save("EllipsePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}