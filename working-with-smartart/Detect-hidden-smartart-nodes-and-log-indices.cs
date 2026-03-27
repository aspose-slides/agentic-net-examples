using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtHiddenNodeDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!System.IO.File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load presentation
            Presentation presentation = new Presentation(inputPath);

            // Access first slide
            ISlide slide = presentation.Slides[0];

            // Iterate through shapes to find SmartArt diagrams
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.ISmartArt)
                {
                    Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;

                    // Iterate through all nodes and log hidden ones
                    int nodeIndex = 0;
                    foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                    {
                        if (node.IsHidden)
                        {
                            Console.WriteLine("Hidden node found at index: " + nodeIndex);
                        }
                        nodeIndex++;
                    }
                }
            }

            // Save presentation before exit
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}