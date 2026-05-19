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