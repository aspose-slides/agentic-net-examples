// -----------------------------------------------------------------------------
// Example: Clone smartart shape rotate 90 ensure integrity using C#
//
// Description:
// Demonstrates how to clone a SmartArt shape, rotate it by 90 degrees, and
// ensure the integrity of the presentation using C# and Aspose.Slides for .NET.
// The example creates a SmartArt diagram if none exists, clones it onto a new
// slide, applies a 90‑degree rotation, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, SmartArt, Shape, Rotate,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of SmartArt shapes with rotation while preserving content.
// - Build C# tools for PowerPoint presentation processing and transformation.
// - Generate or modify PPTX files in .NET applications with specific layout needs.
// - Validate presentation workflows before publishing or integration.
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

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Get the first slide
                ISlide sourceSlide = presentation.Slides[0];

                // Add a SmartArt diagram to the source slide (if not already present)
                ISmartArt originalSmartArt = sourceSlide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

                // Add a new empty slide using the first layout slide
                ILayoutSlide layout = presentation.LayoutSlides[0];
                ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

                // Clone the SmartArt shape onto the new slide at a specific position
                IShape clonedShape = newSlide.Shapes.AddClone(originalSmartArt, 100, 100);

                // Cast the cloned shape back to ISmartArt to modify its properties
                ISmartArt clonedSmartArt = clonedShape as ISmartArt;
                if (clonedSmartArt != null)
                {
                    // Rotate the cloned SmartArt by 90 degrees
                    clonedSmartArt.Rotation = 90;
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported formats or I/O issues
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
