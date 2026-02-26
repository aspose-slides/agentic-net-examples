using System;
using System.Drawing;
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
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

        // Set the shape's fill type to solid
        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;

        // Set the solid fill color to Chocolate
        shape.FillFormat.SolidFillColor.Color = Color.Chocolate;

        // Save the presentation to a PPTX file
        presentation.Save("SetShapeFillSolid_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}