// -----------------------------------------------------------------------------
// Example: Remove smartart node at specific index reflow using C#
//
// Description:
// Demonstrates how to remove a SmartArt node at a specific zero‑based index
// causing the diagram to automatically reflow, using C# and Aspose.Slides for .NET.
// The example loads a presentation, adds a SmartArt diagram if none exists,
// removes the node, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, SmartArt, Node,
// Specific, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate removal of a SmartArt node at a given index with automatic reflow.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace RemoveSmartArtNode
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "input.pptx";
            string outputFile = "output.pptx";
            int nodeIndexToRemove = 2; // zero‑based index

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file does not exist: " + inputFile);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile))
                {
                    // Ensure there is at least one slide
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Add a SmartArt diagram if none exists (for demonstration)
                    Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                        20f, 20f, 600f, 500f,
                        Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

                    // Remove the node at the specified index; the diagram will automatically reflow
                    smartArt.AllNodes.RemoveNode(nodeIndexToRemove);

                    // Save the presentation
                    try
                    {
                        presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                    catch (NotSupportedException)
                    {
                        // Format not supported
                        Console.WriteLine("The requested save format is not supported.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
