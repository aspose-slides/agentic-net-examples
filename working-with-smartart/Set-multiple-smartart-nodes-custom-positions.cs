// -----------------------------------------------------------------------------
// Example: Set multiple smartart nodes custom positions using C#
//
// Description:
// Demonstrates how to set custom positions, sizes, and rotation for multiple
// SmartArt nodes in a PowerPoint presentation using Aspose.Slides for .NET.
// The example loads or creates a presentation, adds an Organization Chart
// SmartArt diagram, modifies the geometry of several nodes, and saves the
// result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Multiple, SmartArt, Nodes,
// Custom, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate custom positioning, resizing, and rotation of SmartArt nodes.
// - Build C# tools for detailed SmartArt diagram manipulation in PowerPoint.
// - Generate or transform PPTX files with tailored SmartArt layouts in .NET
//   applications.
// - Validate SmartArt diagram adjustments before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SetMultipleSmartArtNodesCustomPositions
{
    class Program
    {
        static void Main()
        {
            // Define input and output file paths
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Ensure the data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Load existing presentation if it exists; otherwise create a new one
            Aspose.Slides.Presentation presentation;
            if (File.Exists(inputPath))
            {
                try
                {
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                catch (Exception ex)
                {
                    // Handle any loading errors (e.g., unsupported format)
                    Console.WriteLine("Error loading presentation: " + ex.Message);
                    return;
                }
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }

            // Add a SmartArt diagram to the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

            // Adjust positions of child node shapes
            // Node 1
            Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes[1];
            Aspose.Slides.SmartArt.ISmartArtShape shape = node.Shapes[1];
            shape.X += (shape.Width * 2);
            shape.Y -= (shape.Height / 2);

            // Node 2
            node = smartArt.AllNodes[2];
            shape = node.Shapes[1];
            shape.Width += (shape.Width / 2);

            // Node 3
            node = smartArt.AllNodes[3];
            shape = node.Shapes[1];
            shape.Height += (shape.Height / 2);

            // Node 4
            node = smartArt.AllNodes[4];
            shape = node.Shapes[1];
            shape.Rotation = 90;

            // Save the presentation
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                presentation.Dispose();
            }
        }
    }
}
