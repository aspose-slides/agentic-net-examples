using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfJpegQualitySetter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expected arguments: inputPath outputPath jpegQualityThreshold
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: SwfJpegQualitySetter <inputPath> <outputPath> <jpegQualityThreshold>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];
            string qualityArg = args[2];

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            int jpegQualityThreshold;
            if (!Int32.TryParse(qualityArg, out jpegQualityThreshold) || jpegQualityThreshold < 0 || jpegQualityThreshold > 100)
            {
                Console.WriteLine("Invalid JPEG quality threshold. It must be an integer between 0 and 100.");
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Create SWF options and set JPEG quality based on the threshold
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.JpegQuality = jpegQualityThreshold;

                // Save the presentation as SWF with the specified options
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                // Dispose the presentation before exiting
                presentation.Dispose();

                Console.WriteLine("Presentation saved to SWF with JPEG quality set to " + jpegQualityThreshold);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}