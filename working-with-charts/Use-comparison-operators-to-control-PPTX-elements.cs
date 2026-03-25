using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideComparisonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Error: Input file '{inputPath}' not found.");
                return;
            }

            // Load the presentation
            using (var presentation = new Presentation(inputPath))
            {
                // Iterate through all slides and apply conditional logic
                foreach (var slide in presentation.Slides)
                {
                    // Hide even-numbered slides, show odd-numbered slides
                    if (slide.SlideNumber % 2 == 0)
                    {
                        slide.Hidden = true;
                    }
                    else
                    {
                        slide.Hidden = false;
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }

            Console.WriteLine($"Presentation saved to '{outputPath}'.");
        }
    }
}