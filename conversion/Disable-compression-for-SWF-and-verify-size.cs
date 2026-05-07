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
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string compressedSwfPath = Path.Combine(Directory.GetCurrentDirectory(), "output_compressed.swf");
            string uncompressedSwfPath = Path.Combine(Directory.GetCurrentDirectory(), "output_uncompressed.swf");

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

                // Save with default compression (Compressed = true)
                presentation.Save(compressedSwfPath, SaveFormat.Swf);

                // Save with compression disabled
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.Compressed = false;
                presentation.Save(uncompressedSwfPath, SaveFormat.Swf, swfOptions);

                // Dispose the presentation
                presentation.Dispose();

                // Get file sizes
                FileInfo compressedInfo = new FileInfo(compressedSwfPath);
                FileInfo uncompressedInfo = new FileInfo(uncompressedSwfPath);
                long compressedSize = compressedInfo.Length;
                long uncompressedSize = uncompressedInfo.Length;

                // Verify uncompressed size is at least 20% larger than compressed size
                if (uncompressedSize >= (long)(compressedSize * 1.2))
                {
                    Console.WriteLine("Verification passed: uncompressed SWF is at least 20% larger than compressed SWF.");
                }
                else
                {
                    Console.WriteLine("Verification failed: uncompressed SWF is not sufficiently larger than compressed SWF.");
                }
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