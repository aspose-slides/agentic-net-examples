using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.tiff";

        // Verify input file exists
        if (!System.IO.File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation
        Presentation presentation = null;
        try
        {
            presentation = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Configure TiffOptions for true black‑and‑white output with minimal size
        TiffOptions options = new TiffOptions();
        options.PixelFormat = ImagePixelFormat.Format1bppIndexed;
        options.CompressionType = TiffCompressionTypes.CCITT4;
        options.BwConversionMode = BlackWhiteConversionMode.Dithering;
        // Required by rule structure; no specific layout options needed
        options.SlidesLayoutOptions = null;

        // Save the presentation as TIFF
        try
        {
            presentation.Save(outputPath, SaveFormat.Tiff, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save TIFF: " + ex.Message);
        }

        // Clean up
        presentation.Dispose();
    }
}