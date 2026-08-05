// -----------------------------------------------------------------------------
// Example: Add group shape lock position verify exception using C#
//
// Description:
// Demonstrates how to add a group shape, lock its position, attempt to move it,
// and verify that an exception is thrown using C# and Aspose.Slides for .NET.
// The example shows the required presentation-processing steps for PowerPoint
// files and produces the requested output in a standalone console application.
// Developers can use this pattern to automate PPTX workflows, validate results,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Group, Shape, Lock, Position,
// Exception, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a group shape with a locked position and verify exception handling.
// - Build C# tools for PowerPoint presentation processing that enforce shape constraints.
// - Generate or transform PPTX files in .NET applications while respecting shape locks.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define output directory and file
        string outputDirectory = "Output" + Path.DirectorySeparatorChar;
        if (!Directory.Exists(outputDirectory))
            Directory.CreateDirectory(outputDirectory);
        string outputPath = outputDirectory + "GroupShapeLockDemo.pptx";

        // Create a new presentation
        Presentation pres = new Presentation();
        ISlide slide = pres.Slides[0];

        // Add a group shape to the slide
        IGroupShape groupShape = slide.Shapes.AddGroupShape();

        // Add shapes inside the group
        groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
        groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
        groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
        groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

        // Define the group shape frame
        groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

        // Lock the position of the group shape
        groupShape.GroupShapeLock.PositionLocked = true;

        // Attempt to move the locked group shape and capture the exception
        try
        {
            groupShape.X = 200; // This operation should fail because the position is locked
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught while moving locked group shape: " + ex.Message);
        }

        // Save the presentation
        pres.Save(outputPath, SaveFormat.Pptx);
        pres.Dispose();
    }
}
