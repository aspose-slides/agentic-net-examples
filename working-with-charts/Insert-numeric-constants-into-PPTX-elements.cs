using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertNumericConstants
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Predefined numeric constant for the first slide number
            int firstSlideNumber = 5;

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Apply the numeric constant to the presentation
            presentation.FirstSlideNumber = firstSlideNumber;

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}