using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ResetSlideNumberExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Remove the first slide using reference
                Aspose.Slides.ISlide firstSlide = pres.Slides[0];
                pres.Slides.Remove(firstSlide);

                // Reset the first slide number to maintain correct numbering
                pres.FirstSlideNumber = 1;

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Release resources
                pres.Dispose();

                Console.WriteLine("Presentation processed and saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}