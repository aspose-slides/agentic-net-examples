// -----------------------------------------------------------------------------
// Example: Export slide as TIFF high resolution LZW using C#
//
// Description:
// Demonstrates how to export each slide of a PowerPoint presentation as a
// high‑resolution TIFF image using LZW compression with Aspose.Slides for .NET.
// The example loads a PPTX file, configures TIFF export options, saves each
// slide as a separate TIFF file, and optionally saves the original presentation.
// This pattern can be used to automate slide‑to‑image conversion in .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Slide, TIFF, High Resolution,
// LZW, Presentation Processing, Office Automation
//
// Use Cases:
// - Convert slides to high‑resolution TIFF images for printing or archiving.
// - Build C# utilities for batch slide image extraction.
// - Integrate slide‑to‑image conversion into document management workflows.
// - Validate and process PPTX files before publishing or distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input presentation path
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            Presentation presentation = new Presentation(inputPath);

            // Configure TIFF options with LZW compression and high DPI
            TiffOptions tiffOptions = new TiffOptions();
            tiffOptions.CompressionType = TiffCompressionTypes.LZW;
            tiffOptions.DpiX = 300U;
            tiffOptions.DpiY = 300U;

            // Export each slide as a separate high‑resolution TIFF file
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                ISlide slide = presentation.Slides[i];
                using (IImage image = slide.GetImage(tiffOptions))
                {
                    string outputFile = Path.Combine(Directory.GetCurrentDirectory(), $"slide_{i + 1}.tiff");
                    image.Save(outputFile, Aspose.Slides.ImageFormat.Tiff);
                }
            }

            // Save the presentation before exiting (optional)
            string outputPresentationPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
            presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
