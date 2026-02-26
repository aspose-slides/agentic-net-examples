using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

        // Set the fill of the shape to solid white
        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.White;

        // Adjust the line width of the shape
        shape.LineFormat.Width = 5.0;

        // Save the presentation
        presentation.Save("AdjustShapeLineWidth_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}