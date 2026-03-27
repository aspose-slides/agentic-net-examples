using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace DecorativeSmartArtDemo
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
            Presentation presentation = new Presentation(inputPath);

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Iterate through all shapes on the slide
            foreach (IShape shape in slide.Shapes)
            {
                // Mark the shape as decorative
                shape.IsDecorative = true;

                // If the shape is a SmartArt diagram, also mark its internal shapes as decorative
                if (shape is SmartArt)
                {
                    SmartArt smartArt = (SmartArt)shape;
                    smartArt.IsDecorative = true;

                    // Iterate through all nodes of the SmartArt
                    foreach (ISmartArtNode node in smartArt.AllNodes)
                    {
                        // Iterate through all shapes within each node
                        foreach (ISmartArtShape nodeShape in node.Shapes)
                        {
                            nodeShape.IsDecorative = true;
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}