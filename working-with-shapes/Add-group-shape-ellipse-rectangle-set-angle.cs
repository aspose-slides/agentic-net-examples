// -----------------------------------------------------------------------------
// Example: Add group shape ellipse rectangle set angle using C#
//
// Description:
// Demonstrates how to create a group shape containing multiple rectangles and an
// ellipse, set the group's frame, apply a rotation angle, and save the result as
// a PPTX file using Aspose.Slides for .NET. The example illustrates the required
// presentation-processing steps for PowerPoint files and produces the requested
// output in a standalone console application. Developers can use this pattern to
// automate PPTX workflows, validate results, or integrate presentation logic into
// .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Group Shape, Ellipse, Rectangle,
// Rotation, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of grouped shapes with specific geometry and rotation.
// - Build C# tools for PowerPoint presentation processing involving grouped
//   shapes.
// - Generate or transform PPTX files with custom shape arrangements in .NET
//   applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output directory
        string outDir = "Output" + Path.DirectorySeparatorChar;
        if (!Directory.Exists(outDir))
            Directory.CreateDirectory(outDir);

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Access the shape collection of the slide
        Aspose.Slides.IShapeCollection shapes = slide.Shapes;

        // Add a group shape to the slide
        Aspose.Slides.IGroupShape group = shapes.AddGroupShape();

        // Add rectangles inside the group (as per the create-group-shape example)
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 300, 100, 100, 100);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 500, 100, 100, 100);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 300, 300, 100, 100);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 500, 300, 100, 100);

        // Add an ellipse and an additional rectangle inside the group
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 150, 150, 200, 100);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 300, 120, 80);

        // Set the group shape's frame (optional, demonstrates frame usage)
        group.Frame = new Aspose.Slides.ShapeFrame(100, 300, 500, 40, Aspose.Slides.NullableBool.False, Aspose.Slides.NullableBool.False, 0);

        // Set rotation angle for the group shape
        group.Rotation = 45f;

        // Save the presentation
        string outPath = Path.Combine(outDir, "GroupShapeWithEllipse.pptx");
        try
        {
            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
        finally
        {
            pres.Dispose();
        }
    }
}
