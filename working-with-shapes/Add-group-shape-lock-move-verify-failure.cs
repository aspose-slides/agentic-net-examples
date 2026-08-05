// -----------------------------------------------------------------------------
// Example: Add group shape lock move verify failure using C#
//
// Description:
// Demonstrates how to add a group shape, lock its position, attempt to move it,
// verify that the move is prevented, and save the presentation using C# and
// Aspose.Slides for .NET. The example shows the required presentation-processing
// steps for PowerPoint files and produces the requested output in a standalone
// console application. Developers can use this pattern to automate PPTX workflows,
// validate shape lock behavior, or integrate presentation logic into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Group, Shape, Lock, Move,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a group shape with locked position and verify lock enforcement.
// - Build C# tools for PowerPoint presentation processing and validation.
// - Generate or transform PPTX files in .NET applications while respecting shape locks.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            var slide = pres.Slides[0];

            // Add an empty group shape
            var groupShape = slide.Shapes.AddGroupShape();

            // Set initial position
            groupShape.X = 100;
            groupShape.Y = 100;

            // Lock moving of the group shape
            groupShape.GroupShapeLock.PositionLocked = true;

            // Store original position
            float originalX = groupShape.X;
            float originalY = groupShape.Y;

            // Attempt to move the group shape
            try
            {
                groupShape.X += 50;
                groupShape.Y += 50;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while moving: " + ex.Message);
            }

            // Verify if position changed
            bool moved = (groupShape.X != originalX) || (groupShape.Y != originalY);
            Console.WriteLine(moved ? "Move succeeded (lock not enforced)." : "Move failed as expected due to lock.");

            // Save the presentation
            try
            {
                pres.Save("GroupShapeLockDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
                // Format not supported.
            }
        }
    }
}
