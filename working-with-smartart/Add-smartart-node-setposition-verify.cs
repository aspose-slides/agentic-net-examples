// -----------------------------------------------------------------------------
// Example: Add smartart node setposition verify using C#
//
// Description:
// Demonstrates how to add a SmartArt node, set its position, and verify the
// position using C# and Aspose.Slides for .NET. The example shows the required
// presentation-processing steps for PowerPoint files and produces the
// requested output in a standalone console application. Developers can use
// this pattern to automate PPTX workflows, validate SmartArt manipulations,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Node, SetPosition,
// Verify, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding SmartArt nodes and setting their positions.
// - Build C# tools for PowerPoint SmartArt manipulation and verification.
// - Generate or transform PPTX files with custom SmartArt structures in .NET
//   applications.
// - Validate SmartArt node positioning before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtNodeExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a SmartArt diagram to the slide
                ISmartArt smartArt = slide.Shapes.AddSmartArt(
                    0f,
                    0f,
                    400f,
                    400f,
                    SmartArtLayoutType.BasicBlockList);

                // Add a new node at position 0
                ISmartArtNode newNode = smartArt.Nodes.AddNodeByPosition(0);

                // Set the node's position (zero‑based)
                newNode.Position = 0;

                // Verify that the position was set correctly
                if (newNode.Position == 0)
                {
                    Console.WriteLine("Node position set correctly.");
                }
                else
                {
                    Console.WriteLine("Node position verification failed.");
                }

                // Save the presentation
                presentation.Save("SmartArtNodePosition.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any errors (e.g., unsupported format, file I/O issues)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
