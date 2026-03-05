using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle auto shape and cast it to GeometryShape
        Aspose.Slides.GeometryShape geometryShape = presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100) as Aspose.Slides.GeometryShape;

        // Create a new geometry path
        Aspose.Slides.GeometryPath geometryPath = new Aspose.Slides.GeometryPath();

        // Define a custom shape path (simple rectangle)
        geometryPath.MoveTo(0, 0);
        geometryPath.LineTo(geometryShape.Width, 0);
        geometryPath.LineTo(geometryShape.Width, geometryShape.Height);
        geometryPath.LineTo(0, geometryShape.Height);
        geometryPath.CloseFigure();

        // Apply the custom geometry to the shape
        geometryShape.SetGeometryPath(geometryPath);

        // Save the presentation
        presentation.Save("CustomShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}