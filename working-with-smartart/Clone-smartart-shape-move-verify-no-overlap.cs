// -----------------------------------------------------------------------------
// Example: Clone smartart shape move verify no overlap using C#
//
// Description:
// Demonstrates how to clone a SmartArt shape, move the clone, and verify that
// it does not overlap the original shape using C# and Aspose.Slides for .NET.
// The example creates a presentation, adds a SmartArt diagram, clones it,
// positions the clone, checks for overlap, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, SmartArt, Shape, Move,
// Overlap, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning and repositioning of SmartArt shapes without overlap.
// - Build C# utilities for PowerPoint presentation manipulation.
// - Generate or transform PPTX files while ensuring layout integrity.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram to the slide
            ISmartArt smartArt = slide.Shapes.AddSmartArt(
                0, 0, 400, 400,
                SmartArtLayoutType.BasicBlockList);

            // Clone the SmartArt shape and move the clone to (100, 200)
            IShape clonedShape = slide.Shapes.AddClone(smartArt, 100, 200);

            // Verify that the cloned shape does not overlap the original
            float originalRight = smartArt.X + smartArt.Width;
            float originalBottom = smartArt.Y + smartArt.Height;
            float cloneRight = clonedShape.X + clonedShape.Width;
            float cloneBottom = clonedShape.Y + clonedShape.Height;

            bool noOverlap = (clonedShape.X >= originalRight) ||
                             (smartArt.X >= cloneRight) ||
                             (clonedShape.Y >= originalBottom) ||
                             (smartArt.Y >= cloneBottom);

            Console.WriteLine("No overlap: " + noOverlap);

            // Save the presentation
            presentation.Save("CloneSmartArt_out.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
