using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        var slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

        // Mark the shape as decorative
        shape.IsDecorative = true;

        // Save the presentation
        presentation.Save("DecorativeShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}