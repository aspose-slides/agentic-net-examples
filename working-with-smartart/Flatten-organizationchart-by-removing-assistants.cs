using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace OrganizationChartProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Process each slide
            ISlide slide = presentation.Slides[0];
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                // Identify SmartArt shapes (organization charts)
                if (slide.Shapes[shapeIndex] is ISmartArt smartArt)
                {
                    // Recursively remove assistant nodes and flatten hierarchy
                    RemoveAssistantNodes(smartArt.Nodes);
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }

        // Recursively traverses SmartArt nodes and removes assistants
        private static void RemoveAssistantNodes(ISmartArtNodeCollection nodes)
        {
            // Iterate backwards to safely remove nodes while iterating
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                ISmartArtNode node = nodes[i];

                // If the node is an assistant, remove it
                if (node.IsAssistant)
                {
                    node.Remove();
                }
                else
                {
                    // Process child nodes recursively
                    RemoveAssistantNodes(node.ChildNodes);
                }
            }
        }
    }
}