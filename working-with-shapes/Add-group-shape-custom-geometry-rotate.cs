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
        string outPath = outDir + "GroupCustomShape.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide and its shape collection
        Aspose.Slides.ISlide slide = pres.Slides[0];
        Aspose.Slides.IShapeCollection slideShapes = slide.Shapes;

        // Add a group shape
        Aspose.Slides.IGroupShape group = slideShapes.AddGroupShape();

        // Add some placeholder shapes inside the group
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 300, 100, 100, 100);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 500, 100, 100, 100);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 300, 300, 100, 100);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 500, 300, 100, 100);

        // Set the group frame
        group.Frame = new Aspose.Slides.ShapeFrame(100, 300, 500, 40, Aspose.Slides.NullableBool.False, Aspose.Slides.NullableBool.False, 0);

        // Add a custom geometry shape inside the group
        Aspose.Slides.GeometryShape customShape = group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 150, 200, 100) as Aspose.Slides.GeometryShape;

        // Define complex geometry (triangle)
        Aspose.Slides.IGeometryPath geometryPath = customShape.GetGeometryPaths()[0];
        geometryPath.MoveTo(0, 0);
        geometryPath.LineTo(customShape.Width, 0, 1);
        geometryPath.LineTo(customShape.Width / 2, customShape.Height, 1);
        geometryPath.CloseFigure();

        // Apply geometry to the shape
        customShape.SetGeometryPath(geometryPath);

        // Set rotation
        customShape.Rotation = 45;

        // Save the presentation
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}