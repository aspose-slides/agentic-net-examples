using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DetectHiddenSmartArt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Get the first slide (adjust index as needed)
            ISlide slide = presentation.Slides[0];

            // Iterate through all shapes on the slide
            foreach (IShape shape in slide.Shapes)
            {
                // Check if the shape is a SmartArt diagram
                if (shape is Aspose.Slides.SmartArt.ISmartArt)
                {
                    Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;

                    // Get all nodes in the SmartArt
                    Aspose.Slides.SmartArt.ISmartArtNodeCollection allNodes = smartArt.AllNodes;

                    // Iterate through nodes and log hidden ones
                    for (int i = 0; i < allNodes.Count; i++)
                    {
                        Aspose.Slides.SmartArt.ISmartArtNode node = allNodes[i];
                        if (node.IsHidden)
                        {
                            Console.WriteLine("Hidden SmartArt node found at index: " + i);
                        }
                    }
                }
            }

            // Save the presentation (even if unchanged) before exiting
            string outputPath = "output.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}