// -----------------------------------------------------------------------------
// Example: Remove assistant flags from organization chart using C#
//
// Description:
// Demonstrates how to remove assistant nodes from an organization chart SmartArt
// using C# and Aspose.Slides for .NET. The example loads a PPTX file, locates the
// first SmartArt shape, recursively deletes nodes marked as assistants, and saves
// the modified presentation. This pattern can be used to clean up org charts
// programmatically.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Organization Chart,
// Assistant Nodes, Remove Assistant, Presentation Processing, Office Automation
//
// Use Cases:
// - Clean up organization charts by removing assistant positions.
// - Automate PowerPoint presentation modifications in .NET applications.
// - Prepare PPTX files for publishing without assistant flags.
// - Integrate SmartArt manipulation into custom tools or services.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace RemoveAssistantsFromOrgChart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "OrgChart.pptx";
            string outputPath = "OrgChart_NoAssistants.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Assume the first slide contains the organization chart SmartArt
                ISlide slide = pres.Slides[0];
                if (slide.Shapes.Count == 0)
                {
                    Console.WriteLine("No shapes found on the slide.");
                    pres.Save(outputPath, SaveFormat.Pptx);
                    return;
                }

                // Find the first SmartArt shape (organization chart)
                ISmartArt smartArt = null;
                foreach (IShape shape in slide.Shapes)
                {
                    smartArt = shape as ISmartArt;
                    if (smartArt != null)
                    {
                        break;
                    }
                }

                if (smartArt == null)
                {
                    Console.WriteLine("No SmartArt found on the slide.");
                    pres.Save(outputPath, SaveFormat.Pptx);
                    return;
                }

                // Recursively remove assistant nodes
                RemoveAssistantNodes(smartArt.Nodes);

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Note: If the file format is not supported, the exception will be caught here.
            }
        }

        // Recursively traverses nodes and removes those marked as assistants
        private static void RemoveAssistantNodes(ISmartArtNodeCollection nodes)
        {
            // Iterate backwards to safely remove nodes while iterating
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                ISmartArtNode node = nodes[i];
                // Process child nodes first
                if (node.ChildNodes.Count > 0)
                {
                    RemoveAssistantNodes(node.ChildNodes);
                }

                // Remove node if it is an assistant
                if (node.IsAssistant)
                {
                    node.Remove();
                }
            }
        }
    }
}
