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
            // Input PowerPoint file path
            string inputPath = "input.pptx";
            // Output paths for uncompressed and compressed SWF files
            string outputUncompressedPath = "output_uncompressed.swf";
            string outputCompressedPath = "output_compressed.swf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Save without compression
                    Aspose.Slides.Export.SwfOptions uncompressedOptions = new Aspose.Slides.Export.SwfOptions();
                    uncompressedOptions.Compressed = false;
                    presentation.Save(outputUncompressedPath, Aspose.Slides.Export.SaveFormat.Swf, uncompressedOptions);

                    // Save with compression (default is true, set explicitly)
                    Aspose.Slides.Export.SwfOptions compressedOptions = new Aspose.Slides.Export.SwfOptions();
                    compressedOptions.Compressed = true;
                    presentation.Save(outputCompressedPath, Aspose.Slides.Export.SaveFormat.Swf, compressedOptions);
                }

                // Get file sizes
                FileInfo uncompressedInfo = new FileInfo(outputUncompressedPath);
                FileInfo compressedInfo = new FileInfo(outputCompressedPath);

                long uncompressedSize = uncompressedInfo.Length;
                long compressedSize = compressedInfo.Length;

                // Calculate percentage reduction
                double reduction = 0;
                if (uncompressedSize > 0)
                {
                    reduction = ((double)(uncompressedSize - compressedSize) / uncompressedSize) * 100;
                }

                Console.WriteLine("Uncompressed SWF size: " + uncompressedSize + " bytes");
                Console.WriteLine("Compressed SWF size: " + compressedSize + " bytes");
                Console.WriteLine("Size reduction: " + reduction.ToString("F2") + " %");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported.
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}