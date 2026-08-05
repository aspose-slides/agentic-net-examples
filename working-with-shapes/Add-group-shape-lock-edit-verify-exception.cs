// -----------------------------------------------------------------------------
// Example: Add group shape lock edit verify exception using C#
//
// Description:
// Demonstrates how to add a group shape, lock its grouping to prevent further
// modifications, attempt to add a shape which triggers an exception, handle the
// exception, and save the presentation using Aspose.Slides for .NET. This
// example illustrates the required presentation-processing steps for PowerPoint
// files and produces the requested output in a standalone console application.
// Developers can use this pattern to automate PPTX workflows, validate results,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Group, Shape, Lock, Edit,
// Exception, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate add group shape lock edit verify exception.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Add a group shape to the slide
        IGroupShape groupShape = slide.Shapes.AddGroupShape();

        // Lock the group shape to prevent adding new shapes
        groupShape.GroupShapeLock.GroupingLocked = true;

        try
        {
            // Attempt to add a rectangle to the locked group shape
            groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
        }
        catch (Exception ex)
        {
            // Handle the exception when adding is forbidden
            Console.WriteLine("Exception caught: " + ex.Message);
        }

        // Save the presentation
        string outputPath = "GroupShapeLockExample.pptx";
        pres.Save(outputPath, SaveFormat.Pptx);
        pres.Dispose();
    }
}
