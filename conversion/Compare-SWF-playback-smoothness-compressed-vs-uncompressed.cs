using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfComparisonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file
            string inputPath = "input.pptx";
            // Output SWF files
            string compressedSwfPath = "output_compressed.swf";
            string uncompressedSwfPath = "output_uncompressed.swf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load presentation with custom animations
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Save compressed SWF (default compression)
                    SwfOptions compressedOptions = new SwfOptions();
                    compressedOptions.Compressed = true;
                    presentation.Save(compressedSwfPath, SaveFormat.Swf, compressedOptions);

                    // Save uncompressed SWF
                    SwfOptions uncompressedOptions = new SwfOptions();
                    uncompressedOptions.Compressed = false;
                    presentation.Save(uncompressedSwfPath, SaveFormat.Swf, uncompressedOptions);
                }

                // At this point both SWF files are generated.
                // Playback smoothness comparison should be performed using a SWF player or automated testing tool.
                // Example: measure frame rendering time for each file and compare the results.
                Console.WriteLine("SWF files generated successfully.");
                Console.WriteLine("Compressed SWF: " + compressedSwfPath);
                Console.WriteLine("Uncompressed SWF: " + uncompressedSwfPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}