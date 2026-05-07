using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.tif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Configure TIFF options: 1bpp pixel format, CCITT4 compression, dithering conversion
            Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
            tiffOptions.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.CCITT4;
            tiffOptions.BwConversionMode = Aspose.Slides.Export.BlackWhiteConversionMode.Dithering;
            tiffOptions.PixelFormat = Aspose.Slides.Export.ImagePixelFormat.Format1bppIndexed;

            // Save the presentation as a black‑and‑white TIFF
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);

            // Compare visual fidelity between original and TIFF (implementation omitted)
            // TODO: Load both images and perform pixel‑wise comparison.

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}