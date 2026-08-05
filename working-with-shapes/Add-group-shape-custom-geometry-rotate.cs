// -----------------------------------------------------------------------------
// Example: Add group shape custom geometry rotate using C#
//
// Description:
// Demonstrates how to add a group shape, insert a custom geometry shape inside
// the group, define a triangle geometry, rotate the shape, and save the
// presentation using Aspose.Slides for .NET. The example shows the required
// presentation-processing steps for PowerPoint files and produces the
// requested output in a standalone console application. Developers can use
// this pattern to automate PPTX workflows, validate results, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Group, Shape, Custom Geometry,
// Rotation, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding group shapes with custom geometry and rotation.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with custom shaped content in .NET.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
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
