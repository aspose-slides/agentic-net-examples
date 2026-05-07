using System;
using System.IO;
using Aspose.Slides.Export;

namespace SlideSelector
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "selected_slides.pptx";

            // Define the slide numbers to extract (1‑based indexing)
            int[] slideIndices = new int[] { 1, 3, 5 };

            // Verify that the source file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the source presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Save only the selected slides to a new PPTX file
                    presentation.Save(outputPath, slideIndices, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("Selected slides saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested file format is not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}