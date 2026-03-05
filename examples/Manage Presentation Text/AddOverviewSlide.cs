using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide (automatically created)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a title shape
        Aspose.Slides.IAutoShape titleShape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,
            50f, 50f, 600f, 100f);
        titleShape.AddTextFrame("Presentation Overview");

        // Add a subtitle shape
        Aspose.Slides.IAutoShape subtitleShape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,
            50f, 200f, 600f, 50f);
        subtitleShape.AddTextFrame("Generated using Aspose.Slides");

        // Save the presentation to a file
        presentation.Save("Overview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}