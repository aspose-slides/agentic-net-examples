using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

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
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Get the first slide (use ISlide as per compiler rule)
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Add a SmartArt diagram if none exists (for demonstration)
                    // This creates a BasicBlockList layout SmartArt
                    Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                        0f, 0f, 400f, 400f,
                        Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

                    // Index of the node to delete (zero‑based)
                    int nodeIndexToDelete = 1; // delete the second root node

                    // Ensure the index is within the collection bounds
                    if (nodeIndexToDelete >= 0 && nodeIndexToDelete < smartArt.Nodes.Count)
                    {
                        // Remove the node; the diagram automatically reflows
                        smartArt.Nodes.RemoveNode(nodeIndexToDelete);

                        // Optionally reapply the same layout to force hierarchy update
                        smartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList;
                    }
                    else
                    {
                        Console.WriteLine("Node index out of range.");
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O, Aspose.Slides internal errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}