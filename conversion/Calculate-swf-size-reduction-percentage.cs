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

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Calculate and display compression reduction
                double reduction = CalculateSwfCompressionReduction(inputPath);
                Console.WriteLine($"Compression reduction: {reduction:F2}%");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported for SWF conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Calculates percentage reduction in SWF size after enabling compression
        static double CalculateSwfCompressionReduction(string inputFilePath)
        {
            // Prepare output file paths
            string directory = Path.GetDirectoryName(inputFilePath);
            string outputNoCompress = Path.Combine(directory, "output_no_compress.swf");
            string outputCompress = Path.Combine(directory, "output_compress.swf");

            // Load presentation
            using (Presentation presentation = new Presentation(inputFilePath))
            {
                // Save without compression
                SwfOptions optionsNoCompress = new SwfOptions();
                optionsNoCompress.Compressed = false;
                presentation.Save(outputNoCompress, SaveFormat.Swf, optionsNoCompress);

                // Save with compression (default true)
                SwfOptions optionsCompress = new SwfOptions();
                optionsCompress.Compressed = true;
                presentation.Save(outputCompress, SaveFormat.Swf, optionsCompress);
            }

            // Get file sizes
            FileInfo infoNoCompress = new FileInfo(outputNoCompress);
            FileInfo infoCompress = new FileInfo(outputCompress);
            long sizeNoCompress = infoNoCompress.Length;
            long sizeCompress = infoCompress.Length;

            // Calculate reduction percentage
            double reduction = 0;
            if (sizeNoCompress > 0)
            {
                reduction = ((double)(sizeNoCompress - sizeCompress) / sizeNoCompress) * 100;
            }

            // Return the calculated reduction
            return reduction;
        }
    }
}