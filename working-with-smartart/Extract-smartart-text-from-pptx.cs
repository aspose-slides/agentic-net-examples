using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtTextExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Iterate through slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];

                // Iterate through shapes on the slide
                foreach (IShape shape in slide.Shapes)
                {
                    // Check if the shape is a SmartArt diagram
                    if (shape is Aspose.Slides.SmartArt.ISmartArt)
                    {
                        Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;

                        // Get all nodes of the SmartArt
                        Aspose.Slides.SmartArt.ISmartArtNodeCollection nodes = smartArt.AllNodes;

                        // Iterate through each node
                        foreach (Aspose.Slides.SmartArt.ISmartArtNode node in nodes)
                        {
                            // Extract text from the node's TextFrame if it exists
                            if (node.TextFrame != null && node.TextFrame.Text != null)
                            {
                                Console.WriteLine("Slide {0}, Node Text: {1}", slideIndex + 1, node.TextFrame.Text);
                            }

                            // Additionally, extract text from shapes inside the node
                            foreach (Aspose.Slides.SmartArt.ISmartArtShape smartShape in node.Shapes)
                            {
                                if (smartShape.TextFrame != null && smartShape.TextFrame.Text != null)
                                {
                                    Console.WriteLine("Slide {0}, SmartArt Shape Text: {1}", slideIndex + 1, smartShape.TextFrame.Text);
                                }
                            }
                        }
                    }
                }
            }

            // Save the presentation before exiting
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}