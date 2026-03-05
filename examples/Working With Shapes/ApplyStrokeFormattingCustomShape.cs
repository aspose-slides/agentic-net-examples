using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape (will be converted to a custom shape if needed)
        Aspose.Slides.GeometryShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100) as Aspose.Slides.GeometryShape;

        // Apply stroke (line) formatting to the shape
        Aspose.Slides.ILineFormat lineFormat = shape.LineFormat;
        lineFormat.Width = 5; // Set line width
        lineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid; // Use solid line fill
        lineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red; // Set line color to red

        // Save the presentation before exiting
        presentation.Save("CustomShapeWithStroke.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}