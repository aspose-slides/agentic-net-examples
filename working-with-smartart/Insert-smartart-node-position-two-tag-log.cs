// -----------------------------------------------------------------------------
// Example: Insert smartart node position two tag log using C#
//
// Description:
// Demonstrates how to insert a SmartArt node at position two, assign a unique
// tag to it, and log the operation using C# and Aspose.Slides for .NET. The
// example shows the required presentation‑processing steps for PowerPoint files
// and produces the requested output in a standalone console application.
// Developers can use this pattern to automate PPTX workflows, validate results,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, SmartArt, Node,
// Position, Tag, Logging, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of a SmartArt node at a specific position with a tag.
// - Build C# tools for PowerPoint presentation processing that require node
//   identification and logging.
// - Generate or transform PPTX files in .NET applications while tracking changes.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtNodeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputFile = "output.pptx";

            try
            {
                // Ensure output directory exists
                string outputDir = Path.GetDirectoryName(Path.GetFullPath(outputFile));
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a SmartArt diagram (Stacked List layout)
                Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.StackedList);

                // Get a root node (first node) to add a child node to
                Aspose.Slides.SmartArt.ISmartArtNode rootNode = smartArt.AllNodes[0];

                // Insert a new child node at position 2 (zero‑based)
                Aspose.Slides.SmartArt.SmartArtNode childNode = (Aspose.Slides.SmartArt.SmartArtNode)((Aspose.Slides.SmartArt.SmartArtNodeCollection)rootNode.ChildNodes).AddNodeByPosition(2);

                // Assign a unique tag to the new node
                string uniqueTag = Guid.NewGuid().ToString();
                childNode.TextFrame.Text = uniqueTag;

                // Log the identifier (using the node's position as an example)
                Console.WriteLine("Added SmartArt node with tag: " + uniqueTag + " at position: " + childNode.Position);

                // Save the presentation
                presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Position is out of range
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
