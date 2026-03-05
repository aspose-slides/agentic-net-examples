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

        // Add a rectangle auto shape (will be converted to custom)
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

        // Cast to GeometryShape to modify geometry
        Aspose.Slides.GeometryShape geometryShape = autoShape as Aspose.Slides.GeometryShape;

        // Create first geometry path (top part)
        Aspose.Slides.GeometryPath path1 = new Aspose.Slides.GeometryPath();
        path1.MoveTo(0, 0);
        path1.LineTo(geometryShape.Width, 0);
        path1.LineTo(geometryShape.Width, geometryShape.Height / 3);
        path1.LineTo(0, geometryShape.Height / 3);
        path1.CloseFigure();

        // Create second geometry path (bottom part)
        Aspose.Slides.GeometryPath path2 = new Aspose.Slides.GeometryPath();
        path2.MoveTo(0, geometryShape.Height / 3 * 2);
        path2.LineTo(geometryShape.Width, geometryShape.Height / 3 * 2);
        path2.LineTo(geometryShape.Width, geometryShape.Height);
        path2.LineTo(0, geometryShape.Height);
        path2.CloseFigure();

        // Apply custom geometry
        geometryShape.SetGeometryPaths(new Aspose.Slides.IGeometryPath[] { path1, path2 });

        // Set fill to solid blue
        geometryShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        geometryShape.FillFormat.SolidFillColor.Color = Color.Blue;

        // Set line (stroke) to solid red with width 2
        geometryShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        geometryShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
        geometryShape.LineFormat.Width = 2;

        // Save the presentation
        presentation.Save("CustomShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}