using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide (created by default)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape that will serve as the title placeholder
        Aspose.Slides.IAutoShape titleShape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, // Shape type
            50,    // X position
            50,    // Y position
            600,   // Width
            100    // Height
        );

        // Add a text frame with the word "Overview"
        titleShape.AddTextFrame("Overview");

        // Save the presentation to a PPTX file
        presentation.Save("OverviewPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}