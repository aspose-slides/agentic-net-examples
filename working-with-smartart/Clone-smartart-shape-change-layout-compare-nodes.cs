using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Assume the first shape on the slide is a SmartArt diagram
                IShape shape = slide.Shapes[0];
                SmartArt originalSmartArt = shape as SmartArt;

                if (originalSmartArt == null)
                {
                    Console.WriteLine("No SmartArt shape found on the first slide.");
                    return;
                }

                // Record node count before cloning
                int originalNodeCount = originalSmartArt.AllNodes.Count;
                Console.WriteLine("Original SmartArt node count: " + originalNodeCount);

                // Clone the SmartArt by adding a new SmartArt with the same layout
                SmartArt clonedSmartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, originalSmartArt.Layout) as SmartArt;

                // Change the layout of the cloned SmartArt to BasicCycle
                clonedSmartArt.Layout = SmartArtLayoutType.BasicCycle;

                // Record node count after layout change
                int clonedNodeCount = clonedSmartArt.AllNodes.Count;
                Console.WriteLine("Cloned SmartArt node count after layout change: " + clonedNodeCount);

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
        }
    }
}