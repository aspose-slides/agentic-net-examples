using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace CloneSmartArtExample
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
            using (Presentation pres = new Presentation(inputPath))
            {
                // Get the first slide (source slide)
                ISlide sourceSlide = pres.Slides[0];

                // Find the first SmartArt shape on the source slide
                ISmartArt sourceSmartArt = null;
                foreach (IShape shape in sourceSlide.Shapes)
                {
                    if (shape is ISmartArt)
                    {
                        sourceSmartArt = (ISmartArt)shape;
                        break;
                    }
                }

                if (sourceSmartArt == null)
                {
                    Console.WriteLine("No SmartArt shape found on the source slide.");
                    return;
                }

                // Clone the entire source slide (the clone will contain the SmartArt shape)
                ISlide clonedSlide = pres.Slides.AddClone(sourceSlide);

                // Locate the cloned SmartArt shape on the new slide
                ISmartArt clonedSmartArt = null;
                foreach (IShape shape in clonedSlide.Shapes)
                {
                    if (shape is ISmartArt)
                    {
                        clonedSmartArt = (ISmartArt)shape;
                        break;
                    }
                }

                if (clonedSmartArt == null)
                {
                    Console.WriteLine("Cloned SmartArt shape not found on the new slide.");
                    return;
                }

                // Apply a 45-degree rotation to the cloned SmartArt shape
                clonedSmartArt.Rotation = 45f;

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}