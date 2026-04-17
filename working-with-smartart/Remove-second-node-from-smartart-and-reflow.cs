using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace RemoveSmartArtNode
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

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Get the first slide
                    ISlide slide = pres.Slides[0];

                    // Add a SmartArt diagram to the slide
                    ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

                    // Access the root nodes collection
                    ISmartArtNodeCollection nodes = smartArt.Nodes;

                    // Ensure there are at least two nodes before attempting removal
                    if (nodes.Count > 1)
                    {
                        // Get the second node (zero‑based index)
                        ISmartArtNode secondNode = nodes[1];

                        // Remove the second node; the remaining nodes will reflow automatically
                        secondNode.Remove();
                    }
                    else
                    {
                        Console.WriteLine("SmartArt does not contain a second node to remove.");
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}