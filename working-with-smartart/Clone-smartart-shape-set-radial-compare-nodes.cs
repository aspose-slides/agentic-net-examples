// -----------------------------------------------------------------------------
// Example: Clone smartart shape set radial compare nodes using C#
//
// Description:
// Demonstrates how to clone a SmartArt shape, change its layout to BasicRadial,
// and compare node counts between the original and cloned SmartArt using C#
// and Aspose.Slides for .NET. The example creates a presentation, adds a
// BasicBlockList SmartArt, clones it, modifies the clone, outputs node counts,
// and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, SmartArt, Shape, Radial,
// Node Count, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of SmartArt shapes and modifying their layouts.
// - Build C# tools for PowerPoint presentation processing and analysis.
// - Generate or transform PPTX files with SmartArt modifications in .NET
//   applications.
// - Validate SmartArt node structures before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation presentation = new Presentation())
        {
            ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram with BasicBlockList layout
            ISmartArt originalSmartArt = slide.Shapes.AddSmartArt(50, 50, 400, 400, SmartArtLayoutType.BasicBlockList);

            // Clone the SmartArt shape
            IShape clonedShape = slide.Shapes.AddClone(originalSmartArt, 500, 50);
            ISmartArt clonedSmartArt = clonedShape as ISmartArt;

            if (clonedSmartArt != null)
            {
                // Change layout of cloned SmartArt to BasicRadial
                clonedSmartArt.Layout = SmartArtLayoutType.BasicRadial;

                // Compare node counts between original and cloned SmartArt
                int originalNodeCount = originalSmartArt.Nodes.Count;
                int clonedNodeCount = clonedSmartArt.Nodes.Count;

                Console.WriteLine("Original SmartArt node count: " + originalNodeCount);
                Console.WriteLine("Cloned SmartArt node count: " + clonedNodeCount);
            }

            // Save the presentation before exiting
            presentation.Save("CloneSmartArtRadial.pptx", SaveFormat.Pptx);
        }
    }
}
