// -----------------------------------------------------------------------------
// Example: Export PowerPoint Slides to Multi-Page TIFF with LZW Compression at 200 DPI
//
// Description:
// This console program loads a PPTX file (or creates a sample if missing), configures
// TIFF export options for LZW compression and a resolution of 200 DPI, and saves the
// presentation as a multi-page TIFF image using Aspose.Slides for .NET. It demonstrates
// automated slide conversion suitable for archiving or printing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, TIFF, LZW, 200 DPI
//
// Use Cases:
// - Convert PowerPoint presentations to high-resolution TIFF images.
// - Automate batch export of slides for archival or printing.
// - Integrate slide-to-image conversion into .NET tools or services.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace ExportSlideToTiff
{
    class Program
    {
        static int Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = "output.tiff";

            try
            {
                if (!File.Exists(inputPath))
                {
                    // Create a simple sample presentation
                    Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide firstSlide = samplePresentation.Slides[0];
                    Aspose.Slides.IAutoShape autoShape = firstSlide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                    autoShape.AddTextFrame("Sample Slide");
                    samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePresentation.Dispose();
                }

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Configure TIFF export options
                Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
                tiffOptions.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.LZW;
                tiffOptions.DpiX = 200;
                tiffOptions.DpiY = 200;

                // Save as multi-page TIFF
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
                presentation.Dispose();

                Console.WriteLine("Presentation exported successfully to: " + outputPath);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return 1;
            }
        }
    }
}
