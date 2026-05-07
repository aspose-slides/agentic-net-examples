using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfJpegQualityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.swf";

            // Configuration threshold for JPEG quality
            int qualityThreshold = 80;
            if (args.Length > 2)
            {
                int parsed;
                if (int.TryParse(args[2], out parsed))
                {
                    qualityThreshold = parsed;
                }
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Create SWF options and set JPEG quality based on configuration
                Aspose.Slides.Export.SwfOptions swfOptions = CreateSwfOptionsWithQuality(qualityThreshold);

                // Save presentation as SWF with the configured options
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                // Dispose presentation
                presentation.Dispose();

                Console.WriteLine("Presentation saved to SWF with JPEG quality: " + swfOptions.JpegQuality);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        // Method to create SwfOptions and set JpegQuality based on a threshold
        private static Aspose.Slides.Export.SwfOptions CreateSwfOptionsWithQuality(int threshold)
        {
            Aspose.Slides.Export.SwfOptions options = new Aspose.Slides.Export.SwfOptions();

            // Ensure quality is within 0-100 range
            if (threshold < 0)
            {
                options.JpegQuality = 0;
            }
            else if (threshold > 100)
            {
                options.JpegQuality = 100;
            }
            else
            {
                options.JpegQuality = threshold;
            }

            return options;
        }
    }
}