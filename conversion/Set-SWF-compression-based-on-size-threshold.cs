using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfCompressionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input, output and size threshold (in bytes)
            string inputPath = "input.pptx";
            string outputPath = "output.swf";
            long sizeThreshold = 5 * 1024 * 1024; // 5 MB

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                SetSwfCompression(inputPath, outputPath, sizeThreshold);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs or web services)
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void SetSwfCompression(string inputPath, string outputPath, long sizeThreshold)
        {
            // Determine file size
            FileInfo fileInfo = new FileInfo(inputPath);
            long fileSize = fileInfo.Length;

            // Load presentation
            Presentation presentation = new Presentation(inputPath);

            // Configure SWF options based on size threshold
            SwfOptions swfOptions = new SwfOptions();
            if (fileSize > sizeThreshold)
            {
                swfOptions.Compressed = false;
            }
            else
            {
                swfOptions.Compressed = true;
            }

            // Save as SWF with the configured options
            presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

            // Dispose presentation
            presentation.Dispose();
        }
    }
}