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

            // Expected file size range (in bytes) based on JPEG quality
            long expectedMinSize = jpegQuality * 1000; // example calculation
            long expectedMaxSize = jpegQuality * 2000; // example calculation

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure SWF options with selected JPEG quality
                    SwfOptions swfOptions = new SwfOptions();
                    swfOptions.JpegQuality = jpegQuality;

                    // Save presentation as SWF
                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                }

                // Verify output file was created
                if (!File.Exists(outputPath))
                {
                    Console.WriteLine("Failed to create SWF file.");
                    return;
                }

                // Get actual file size
                FileInfo fileInfo = new FileInfo(outputPath);
                long actualSize = fileInfo.Length;

                // Validate size against expected range
                if (actualSize >= expectedMinSize && actualSize <= expectedMaxSize)
                {
                    Console.WriteLine("SWF file size is within the expected range.");
                }
                else
                {
                    Console.WriteLine("SWF file size is outside the expected range.");
                    Console.WriteLine("Actual size: " + actualSize + " bytes");
                    Console.WriteLine("Expected range: " + expectedMinSize + " - " + expectedMaxSize + " bytes");
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (System.Net.WebException)
            {
                // External URL or web service error
                Console.WriteLine("An error occurred while accessing an external resource.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}