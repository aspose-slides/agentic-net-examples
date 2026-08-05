// -----------------------------------------------------------------------------
// Example: Set group shape lock move ungroup resize using C#
//
// Description:
// Demonstrates how to set group shape lock move ungroup resize using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Group, Shape, Lock, Move, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate set group shape lock move ungroup resize.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GroupShapeLockDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory and ensure it exists
            string outputDir = "Output" + Path.DirectorySeparatorChar;
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a group shape to the slide
            IGroupShape group = slide.Shapes.AddGroupShape();

            // Add some rectangles to the group shape
            group.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
            group.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 50, 100, 100);
            group.Shapes.AddAutoShape(ShapeType.Rectangle, 350, 50, 100, 100);
            group.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 50, 100, 100);

            // Set the group shape's lock properties:
            // Prevent moving
            group.GroupShapeLock.PositionLocked = true;
            // Prevent ungrouping
            group.GroupShapeLock.UngroupingLocked = true;
            // Allow resizing
            group.GroupShapeLock.SizeLocked = false;

            // Save the presentation
            string outputPath = outputDir + "GroupShapeLockDemo.pptx";
            pres.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
    }
}
