using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace VideoToSwfConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.swf";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation and convert to SWF with error handling
            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Create SWF options (default options are sufficient for this example)
                SwfOptions swfOptions = new SwfOptions();

                // Save presentation as SWF
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                // Dispose presentation before exiting
                presentation.Dispose();

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported for PPT files
                Console.WriteLine("The presentation format is not supported for conversion to SWF.");
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported for PPTX files
                Console.WriteLine("The presentation format is not supported for conversion to SWF.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., issues with embedded videos)
                Console.WriteLine("An error occurred during conversion: " + ex.Message);
            }
        }
    }
}