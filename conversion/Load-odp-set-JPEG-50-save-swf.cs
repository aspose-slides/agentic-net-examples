using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.odp";
            string outputPath = "output.swf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the ODP presentation
                Presentation presentation = new Presentation(inputPath);

                // Configure SWF options with JPEG quality set to 50
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.JpegQuality = 50;

                // Save the presentation as SWF using the configured options
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                // Dispose the presentation object
                presentation.Dispose();

                Console.WriteLine("Presentation successfully saved as SWF.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // The ODP format may not be supported for saving as SWF
                Console.WriteLine("The specified format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}