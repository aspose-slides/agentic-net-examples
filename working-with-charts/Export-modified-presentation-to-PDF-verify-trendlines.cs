using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesPdfExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
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
                Presentation pres = new Presentation(inputPath);

                // Export the presentation to PDF format
                // Using the convert-without-xps-options rule
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The requested format is not supported for saving.
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}