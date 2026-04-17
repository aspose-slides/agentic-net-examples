using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output directory and file
        string outDir = "Output" + Path.DirectorySeparatorChar;
        if (!Directory.Exists(outDir))
            Directory.CreateDirectory(outDir);
        string outPath = Path.Combine(outDir, "GroupCustomShape.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide and its shape collection
        Aspose.Slides.ISlide slide = pres.Slides[0];
        Aspose.Slides.IShapeCollection shapes = slide.Shapes;

        // Add a group shape to the slide
        Aspose.Slides.IGroupShape group = shapes.AddGroupShape();

        // Add a rectangle auto shape inside the group (will be customized)
        Aspose.Slides.IAutoShape rect = group.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100) as Aspose.Slides.IAutoShape;

        // Retrieve the geometry path of the shape
        Aspose.Slides.IGeometryPath[] geometryPaths = (rect as Aspose.Slides.IGeometryShape).GetGeometryPaths();
        Aspose.Slides.IGeometryPath geometryPath = geometryPaths[0];

        // Define a custom geometry (triangle)
        geometryPath.MoveTo(0, 0);
        geometryPath.LineTo(200, 0, 1);
        geometryPath.LineTo(100, 100, 1);
        geometryPath.CloseFigure();

        // Apply the custom geometry to the shape
        (rect as Aspose.Slides.IGeometryShape).SetGeometryPath(geometryPath);

        // Set rotation of the custom shape
        rect.Rotation = 45;

        // Save the presentation
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}