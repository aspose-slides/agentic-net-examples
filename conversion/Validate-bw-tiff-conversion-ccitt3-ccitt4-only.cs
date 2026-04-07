using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BlackWhiteTiffVerification
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input file path
            string inputPath;
            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                inputPath = args[0];
            }
            else
            {
                inputPath = "input.pptx"; // default input
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Determine output file path
            string outputPath = Path.ChangeExtension(inputPath, ".tiff");

            // Load presentation
            Presentation pres = new Presentation(inputPath);

            // Configure TIFF options
            TiffOptions options = new TiffOptions();
            options.CompressionType = TiffCompressionTypes.CCITT4; // valid compression for BW conversion

            // Verify that BW conversion is applied only for CCITT3 or CCITT4
            if (options.CompressionType == TiffCompressionTypes.CCITT3 || options.CompressionType == TiffCompressionTypes.CCITT4)
            {
                options.BwConversionMode = BlackWhiteConversionMode.Dithering;
            }
            else
            {
                // Compression type does not support BW conversion; skip setting mode
                Console.WriteLine("Selected compression does not support black‑and‑white conversion.");
            }

            // Save presentation as black‑and‑white TIFF
            pres.Save(outputPath, SaveFormat.Tiff, options);

            // Clean up
            pres.Dispose();

            Console.WriteLine("TIFF saved to: " + outputPath);
        }
    }
}