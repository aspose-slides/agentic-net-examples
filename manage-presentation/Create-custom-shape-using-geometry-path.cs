// -----------------------------------------------------------------------------
// Example: Create custom shape using geometry path using C#
//
// Description:
// Demonstrates how to create a custom shape by defining composite geometry
// paths on an auto‑generated rectangle shape using Aspose.Slides for .NET.
// The example builds a new presentation, adds a rectangle, replaces its
// geometry with two separate paths, and saves the result as a PPTX file.
// This pattern can be used to programmatically generate complex custom shapes
// in PowerPoint presentations.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Custom Shape, Geometry Path,
// Presentation Automation, Office Automation, Shape Manipulation
//
// Use Cases:
// - Generate custom vector shapes in PowerPoint programmatically.
// - Build .NET tools that need precise shape geometry control.
// - Automate PPTX creation with non‑standard shapes for reports or graphics.
// - Integrate custom shape generation into larger presentation workflows.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a rectangle auto shape that will be converted to a custom geometry shape
        Aspose.Slides.GeometryShape shape = (Aspose.Slides.GeometryShape)pres.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

        // Define the first geometry path
        Aspose.Slides.GeometryPath geometryPath0 = new Aspose.Slides.GeometryPath();
        geometryPath0.MoveTo(0, 0);
        geometryPath0.LineTo(shape.Width, 0);
        geometryPath0.LineTo(shape.Width, shape.Height / 3);
        geometryPath0.LineTo(0, shape.Height / 3);
        geometryPath0.CloseFigure();

        // Define the second geometry path
        Aspose.Slides.GeometryPath geometryPath1 = new Aspose.Slides.GeometryPath();
        geometryPath1.MoveTo(0, shape.Height / 3 * 2);
        geometryPath1.LineTo(shape.Width, shape.Height / 3 * 2);
        geometryPath1.LineTo(shape.Width, shape.Height);
        geometryPath1.LineTo(0, shape.Height);
        geometryPath1.CloseFigure();

        // Apply composite geometry paths to the shape
        shape.SetGeometryPaths(new Aspose.Slides.IGeometryPath[] { geometryPath0, geometryPath1 });

        // Save the presentation
        pres.Save("CustomShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}
