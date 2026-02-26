using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

        // Set the shape's fill type to solid and assign a color
        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = Color.Blue;

        // Save the presentation
        presentation.Save("MediaShapeFill.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}