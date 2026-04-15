using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Iterate through shapes on the first slide to find a SmartArt diagram
            foreach (Aspose.Slides.IShape shape in pres.Slides[0].Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.SmartArt)
                {
                    Aspose.Slides.SmartArt.SmartArt smartArt = (Aspose.Slides.SmartArt.SmartArt)shape;

                    // Ensure there is at least one node to remove
                    if (smartArt.AllNodes.Count > 0)
                    {
                        // Remove the node at a specific index (e.g., index 0)
                        Aspose.Slides.SmartArt.ISmartArtNode nodeToRemove = smartArt.AllNodes[0];
                        smartArt.AllNodes.RemoveNode(nodeToRemove);
                    }

                    // Exit after processing the first SmartArt found
                    break;
                }
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}