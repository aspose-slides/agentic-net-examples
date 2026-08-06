// -----------------------------------------------------------------------------
// Example: Delete smartart node at index and reflow using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation, add a SmartArt diagram,
// populate it with nodes, delete a node at a specific index, reapply the layout
// to reflow the SmartArt hierarchy, and save the result using Aspose.Slides for .NET.
// The example includes basic error handling and file existence checks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Delete SmartArt Node, Index, Reflow,
// SmartArt Layout, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate removal of a specific SmartArt node and reflow the diagram.
// - Build C# utilities for PowerPoint SmartArt manipulation.
// - Integrate SmartArt editing into .NET applications.
// - Validate SmartArt structures after modifications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

namespace DeleteSmartArtNode
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Retrieve the first slide (use ISlide to avoid CS0266)
                    Aspose.Slides.ISlide slide = pres.Slides[0];

                    // Add a SmartArt diagram (for demonstration purposes)
                    Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                        0, 0, 400, 400,
                        Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

                    // Add a few nodes so that there is a node to delete
                    smartArt.Nodes.AddNode(); // Node at index 0
                    smartArt.Nodes.AddNode(); // Node at index 1
                    smartArt.Nodes.AddNode(); // Node at index 2

                    // Delete the node at position 1 (second node)
                    smartArt.Nodes.RemoveNode(1);

                    // Re-apply the current layout to reflow the hierarchy
                    Aspose.Slides.SmartArt.SmartArtLayoutType currentLayout = smartArt.Layout;
                    smartArt.Layout = currentLayout;

                    // Save the modified presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors (e.g., unsupported format, I/O issues)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
