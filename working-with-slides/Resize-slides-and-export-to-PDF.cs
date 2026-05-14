using System;
using System.IO;
using Aspose.Slides.Export;

namespace SlideResizeAndExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Set custom slide size (e.g., 800x600 points) and ensure content fits
                presentation.SlideSize.SetSize(800f, 600f, Aspose.Slides.SlideSizeScaleType.EnsureFit);

                // Export the modified presentation to PDF
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle the case where the requested format cannot be saved
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., file access issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}