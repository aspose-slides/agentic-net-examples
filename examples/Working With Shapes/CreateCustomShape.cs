using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle auto shape and cast it to GeometryShape for custom geometry
        Aspose.Slides.GeometryShape shape = (Aspose.Slides.GeometryShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

        // Define the first geometry path (upper part)
        Aspose.Slides.GeometryPath path0 = new Aspose.Slides.GeometryPath();
        path0.MoveTo(0, 0);
        path0.LineTo(shape.Width, 0);
        path0.LineTo(shape.Width, shape.Height / 3);
        path0.LineTo(0, shape.Height / 3);
        path0.CloseFigure();

        // Define the second geometry path (lower part)
        Aspose.Slides.GeometryPath path1 = new Aspose.Slides.GeometryPath();
        path1.MoveTo(0, shape.Height / 3 * 2);
        path1.LineTo(shape.Width, shape.Height / 3 * 2);
        path1.LineTo(shape.Width, shape.Height);
        path1.LineTo(0, shape.Height);
        path1.CloseFigure();

        // Apply the composite geometry to the shape
        shape.SetGeometryPaths(new Aspose.Slides.IGeometryPath[] { path0, path1 });

        // Set solid fill color for the shape
        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 0, 0, 255); // Blue fill

        // Set stroke (outline) for the shape
        shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
        shape.LineFormat.Width = 2;

        // Save the presentation
        pres.Save("CustomShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}