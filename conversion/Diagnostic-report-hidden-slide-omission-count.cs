using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DiagnosticTool
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
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Retrieve slide counts
                int totalSlides = pres.DocumentProperties.Slides;
                int hiddenSlides = pres.DocumentProperties.HiddenSlides;
                int omittedSlides = hiddenSlides; // ShowHiddenSlides is false by default

                // Report the diagnostic information
                Console.WriteLine("Total slides in presentation: " + totalSlides);
                Console.WriteLine("Hidden slides omitted (ShowHiddenSlides = false): " + omittedSlides);

                // Save the presentation before exiting
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other loading errors
                Console.WriteLine("An error occurred while processing the presentation: " + ex.Message);
                // Format not supported comment
                // Note: If the exception is due to an unsupported file format, the format is not supported.
            }
        }
    }
}