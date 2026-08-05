// -----------------------------------------------------------------------------
// Example: Export animated chart to highresolution TIFF using C#
//
// Description:
// Demonstrates how to export an animated chart from a PowerPoint presentation
// to a high‑resolution multi‑page TIFF image using C# and Aspose.Slides for .NET.
// The example loads a PPTX file containing an animated chart, configures TIFF
// export options with 300 DPI and LZW compression, and saves the result as a
// TIFF file. This pattern can be used in console applications to automate
// presentation processing tasks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Animated, Chart,
// Highresolution, TIFF, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of animated charts to high‑resolution TIFF images.
// - Build C# tools for PowerPoint presentation processing and image conversion.
// - Generate or transform PPTX files into multi‑page TIFFs in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

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
