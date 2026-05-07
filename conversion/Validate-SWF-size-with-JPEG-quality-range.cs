using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfSizeValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.swf";

            // Desired JPEG quality for SWF conversion
            int jpegQuality = 80;

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Configure SWF options with the selected JPEG quality
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.JpegQuality = jpegQuality;

                // Save the presentation as SWF
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                // Validate the generated SWF file size against an expected range
                FileInfo swfInfo = new FileInfo(outputPath);
                long fileSize = swfInfo.Length;

                // Example expected size range calculation based on JPEG quality
                long expectedMin = jpegQuality * 1000L;   // Minimum expected size in bytes
                long expectedMax = jpegQuality * 2000L;  // Maximum expected size in bytes

                if (fileSize >= expectedMin && fileSize <= expectedMax)
                {
                    Console.WriteLine("SWF file size is within the expected range.");
                }
                else
                {
                    Console.WriteLine("SWF file size is outside the expected range.");
                }

                // Clean up
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}