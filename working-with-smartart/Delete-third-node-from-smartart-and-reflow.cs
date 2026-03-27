using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace DeleteSmartArtNode
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
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Assume the first shape on the slide is a SmartArt diagram
            ISmartArt smartArt = slide.Shapes[0] as ISmartArt;
            if (smartArt == null)
            {
                Console.WriteLine("No SmartArt diagram found on the first slide.");
                pres.Dispose();
                return;
            }

            // Delete the third node (zero‑based index 2) from the SmartArt diagram
            // Using the AllNodes collection to ensure the node is removed regardless of its hierarchy level
            ISmartArtNodeCollection allNodes = smartArt.AllNodes;
            if (allNodes.Count > 2)
            {
                allNodes.RemoveNode(2);
                // After removal, reflow the diagram to maintain hierarchy
                // Setting the same layout forces a layout refresh
                SmartArtLayoutType currentLayout = smartArt.Layout;
                smartArt.Layout = currentLayout;
            }
            else
            {
                Console.WriteLine("The SmartArt diagram does not contain a third node to delete.");
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            pres.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}