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
        string outputPath = "output.tiff";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Set up TIFF options with Dithering black‑and‑white conversion
            Aspose.Slides.Export.TiffOptions options = new Aspose.Slides.Export.TiffOptions();
            options.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.CCITT4;
            options.BwConversionMode = Aspose.Slides.Export.BlackWhiteConversionMode.Dithering;

            // Save the presentation as a black‑and‑white TIFF
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, options);
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}