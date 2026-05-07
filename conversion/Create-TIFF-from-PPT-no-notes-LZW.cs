using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPTX file path
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        // Output multi‑page TIFF file path
        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.tiff");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Configure TIFF options with LZW compression (default)
            Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
            tiffOptions.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.LZW;

            // Save all slides (notes are excluded by default) as a multi‑page TIFF
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);

            // Release resources
            presentation.Dispose();

            Console.WriteLine("TIFF created successfully at: " + outputPath);
        }
        catch (NotSupportedException)
        {
            // Handle unsupported format
            Console.WriteLine("The provided file format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}