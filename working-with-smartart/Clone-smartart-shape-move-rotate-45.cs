// -----------------------------------------------------------------------------
// Example: Clone smartart shape move rotate 45 using C#
//
// Description:
// Demonstrates how to clone a SmartArt shape, reposition it, and rotate it
// by 45 degrees using C# and Aspose.Slides for .NET. The example loads an
// existing presentation (or creates a new one), ensures a SmartArt shape is
// present, clones it onto a new slide at coordinates (50,50), applies a
// 45‑degree rotation, and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, SmartArt, Shape, Move,
// Rotate, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of SmartArt shapes with repositioning and rotation.
// - Build C# utilities for PowerPoint presentation manipulation.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate SmartArt layout transformations before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        Presentation presentation = null;
        try
        {
            if (File.Exists(inputPath))
            {
                presentation = new Presentation(inputPath);
            }
            else
            {
                presentation = new Presentation();
            }
        }
        catch (Exception)
        {
            // Format not supported
            Console.WriteLine("Failed to load the presentation. The file format may not be supported.");
            return;
        }

        // Ensure there is at least one slide
        ISlide sourceSlide = presentation.Slides[0];

        // Add a SmartArt shape if none exists on the source slide
        ISmartArt smartArt = null;
        if (sourceSlide.Shapes.Count == 0)
        {
            smartArt = sourceSlide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
        }
        else
        {
            foreach (IShape shape in sourceSlide.Shapes)
            {
                if (shape is ISmartArt)
                {
                    smartArt = (ISmartArt)shape;
                    break;
                }
            }
            if (smartArt == null)
            {
                smartArt = sourceSlide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
            }
        }

        // Create a new empty slide using the same layout as the source slide
        ILayoutSlide layout = sourceSlide.LayoutSlide;
        ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

        // Clone the SmartArt shape onto the new slide at position (50, 50)
        IShape clonedShape = newSlide.Shapes.AddClone((IShape)smartArt, 50, 50);

        // Apply a 45-degree rotation to the cloned shape
        clonedShape.Rotation = 45f;

        // Save the presentation
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            presentation.Dispose();
        }
    }
}
