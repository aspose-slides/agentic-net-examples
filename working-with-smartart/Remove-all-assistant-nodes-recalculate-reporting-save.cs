// -----------------------------------------------------------------------------
// Example: Remove all assistant nodes recalculate reporting save using C#
//
// Description:
// Demonstrates how to remove all assistant nodes from a SmartArt organization
// chart, recalculate the reporting hierarchy, and save the updated presentation
// using C# and Aspose.Slides for .NET. The example shows the required
// presentation-processing steps for PowerPoint files and produces the
// requested output in a standalone console application. Developers can use
// this pattern to automate PPTX workflows, validate results, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Assistant, Nodes,
// SmartArt, Organization Chart, Recalculate, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate removal of all assistant nodes and recalculate reporting in SmartArt.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate SmartArt organization chart workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace RemoveAssistantNodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found.");
                return;
            }

            try
            {
                Presentation pres = new Presentation(inputPath);

                // Assume the organization chart is on the first slide
                ISlide slide = pres.Slides[0];

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
                    Console.WriteLine("No SmartArt organization chart found.");
                    pres.Save(outputPath, SaveFormat.Pptx);
                    return;
                }

                List<ISmartArtNode> assistantNodes = new List<ISmartArtNode>();

                // Recursive collection of assistant nodes
                void CollectAssistantNodes(ISmartArtNode node)
                {
                    foreach (ISmartArtNode child in node.ChildNodes)
                    {
                        if (child.IsAssistant)
                        {
                            assistantNodes.Add(child);
                        }
                        CollectAssistantNodes(child);
                    }
                }

                // Start collection from top-level nodes
                foreach (ISmartArtNode topNode in smartArt.Nodes)
                {
                    CollectAssistantNodes(topNode);
                }

                // Remove collected assistant nodes
                foreach (ISmartArtNode assistant in assistantNodes)
                {
                    assistant.Remove();
                }

                // Save the updated presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}
