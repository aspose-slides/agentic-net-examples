using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportAnimatedChartToTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file containing the animated chart
            string inputPath = "AnimatedChart.pptx";
            // Output TIFF file path
            string outputPath = "AnimatedChart.tiff";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure high‑resolution TIFF options
                    TiffOptions tiffOptions = new TiffOptions();
                    tiffOptions.DpiX = 300; // Horizontal DPI
                    tiffOptions.DpiY = 300; // Vertical DPI
                    tiffOptions.CompressionType = TiffCompressionTypes.LZW;

                    // Save the entire presentation as a multi‑page TIFF image
                    presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);
                }

                Console.WriteLine("Export completed successfully.");
            }
            catch (PptxUnsupportedFormatException)
            {
                // The file format is not supported for conversion
                Console.WriteLine("The provided file format is not supported for TIFF export.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors, licensing issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}