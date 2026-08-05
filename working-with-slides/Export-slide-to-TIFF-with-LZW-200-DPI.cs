// -----------------------------------------------------------------------------
// Example: Export slide to TIFF with LZW 200 DPI using C#
//
// Description:
// Demonstrates how to export a PowerPoint presentation to a multi‑page TIFF
// file using LZW compression and a resolution of 200 DPI with Aspose.Slides for
// .NET. The example loads a PPTX file, configures TIFF export options, and
// saves the result as a TIFF image. This pattern can be used in console
// applications to automate slide conversion tasks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Slide, TIFF, LZW,
// 200 DPI, Presentation Processing, Office Automation
//
// Use Cases:
// - Convert PowerPoint presentations to high‑resolution TIFF images.
// - Automate batch export of slides for archival or printing.
// - Integrate slide‑to‑image conversion into .NET tools or services.
// - Validate presentation rendering before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportSlideToTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation file path (first argument or default)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            // Output TIFF file path
            string outputPath = "output.tiff";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Configure TIFF export options: LZW compression and 200 DPI resolution
                TiffOptions tiffOptions = new TiffOptions();
                tiffOptions.CompressionType = TiffCompressionTypes.LZW;
                tiffOptions.DpiX = 200;
                tiffOptions.DpiY = 200;

                // Save the presentation as a multi‑page TIFF file
                presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);

                // Dispose the presentation (optional, using statement could be used)
                presentation.Dispose();

                Console.WriteLine("Presentation exported successfully to: " + outputPath);
            }
            catch (PptxUnsupportedFormatException)
            {
                // Handle unsupported file format
                Console.WriteLine("The provided file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
