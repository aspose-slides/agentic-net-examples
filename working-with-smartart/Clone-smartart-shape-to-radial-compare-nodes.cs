// -----------------------------------------------------------------------------
// Example: Clone smartart shape to radial compare nodes using C#
//
// Description:
// Demonstrates how to clone a SmartArt shape, reposition it, and change its
// layout to a radial layout using C# and Aspose.Slides for .NET. The example
// creates a presentation, adds a basic block list SmartArt, clones it, switches
// the clone to a BasicRadial layout, and outputs node counts before and after
// the layout change. The resulting presentation is saved as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, SmartArt, Shape, Radial,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of SmartArt shapes and converting them to radial layouts.
// - Build C# tools for PowerPoint presentation processing involving SmartArt.
// - Generate or transform PPTX files with customized SmartArt structures in .NET.
// - Validate SmartArt node consistency after layout transformations.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "CloneSmartArtRadial.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt shape with a basic layout
            Aspose.Slides.SmartArt.ISmartArt originalSmartArt = slide.Shapes.AddSmartArt(
                20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            // Get node count before cloning
            int originalNodeCount = originalSmartArt.AllNodes.Count;

            // Clone the SmartArt shape to a new position
            Aspose.Slides.IShape clonedShape = slide.Shapes.AddClone(originalSmartArt, 300, 0);
            Aspose.Slides.SmartArt.ISmartArt clonedSmartArt = clonedShape as Aspose.Slides.SmartArt.ISmartArt;

            // Change the layout of the cloned SmartArt to BasicRadial
            clonedSmartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.BasicRadial;

            // Get node count after cloning (should be the same as original)
            int clonedNodeCount = clonedSmartArt.AllNodes.Count;

            // Output the node counts to the console
            Console.WriteLine("Original SmartArt node count: " + originalNodeCount);
            Console.WriteLine("Cloned SmartArt node count after layout change: " + clonedNodeCount);

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
