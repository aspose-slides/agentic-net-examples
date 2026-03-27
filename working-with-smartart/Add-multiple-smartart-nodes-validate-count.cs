using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtNodeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Try to find an existing SmartArt shape on the slide
            Aspose.Slides.SmartArt.ISmartArt smartArt = null;
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.ISmartArt)
                {
                    smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                    break;
                }
            }

            // If no SmartArt found, create a new one
            if (smartArt == null)
            {
                smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);
            }

            // Record the original node count
            int originalCount = smartArt.AllNodes.Count;

            // Number of nodes to add
            int nodesToAdd = 5;

            // Add new nodes in a loop and assign sequential identifiers
            for (int i = 0; i < nodesToAdd; i++)
            {
                Aspose.Slides.SmartArt.ISmartArtNode newNode = smartArt.AllNodes.AddNode();

                // Assign a sequential identifier as text, if a TextFrame is available
                if (newNode.TextFrame != null)
                {
                    newNode.TextFrame.Text = "Node " + (i + 1);
                }
            }

            // Validate that the node count matches the expected value
            int expectedCount = originalCount + nodesToAdd;
            int actualCount = smartArt.AllNodes.Count;
            if (actualCount == expectedCount)
            {
                Console.WriteLine("Node count validation succeeded. Total nodes: " + actualCount);
            }
            else
            {
                Console.WriteLine("Node count validation failed. Expected: " + expectedCount + ", Actual: " + actualCount);
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            pres.Dispose();
        }
    }
}