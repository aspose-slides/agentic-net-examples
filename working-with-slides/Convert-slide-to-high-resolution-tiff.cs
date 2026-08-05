// -----------------------------------------------------------------------------
// Example: Convert slide to high resolution TIFF using C#
//
// Description:
// Demonstrates how to convert the first slide of a PowerPoint presentation
// to a high‑resolution black‑and‑white TIFF image using Aspose.Slides for .NET.
// The example loads a PPTX file, configures TIFF options with CCITT4 compression
// and 300 DPI, renders the slide, and saves the result as a TIFF file.
// This pattern can be used in console applications to automate slide export
// tasks, validate presentation rendering, or integrate image generation into
// .NET solutions.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Convert, Slide, High, 
// Resolution, TIFF, Compression, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate conversion of a slide to a high‑resolution TIFF image.
// - Build C# utilities for PowerPoint slide export and archiving.
// - Generate or transform PPTX files into printable image formats in .NET.
// - Validate slide rendering quality before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "slide1.tiff";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Get the specific slide (e.g., first slide)
            ISlide slide = presentation.Slides[0];

            // Configure TIFF options with CCITT4 compression and high DPI
            TiffOptions tiffOptions = new TiffOptions();
            tiffOptions.CompressionType = TiffCompressionTypes.CCITT4;
            tiffOptions.BwConversionMode = BlackWhiteConversionMode.Dithering;
            tiffOptions.DpiX = 300U;
            tiffOptions.DpiY = 300U;

            // Render the slide to a TIFF image using the options
            IImage tiffImage = slide.GetImage(tiffOptions);

            // Save the TIFF image to disk
            tiffImage.Save(outputPath, Aspose.Slides.ImageFormat.Tiff);
            tiffImage.Dispose();

            // Clean up
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
