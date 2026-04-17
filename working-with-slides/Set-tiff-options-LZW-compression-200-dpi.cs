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
        string outputPath = "output.tiff";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Create Tiff options using the ITiffOptions interface
            ITiffOptions tiffOptions = new TiffOptions();
            tiffOptions.CompressionType = TiffCompressionTypes.LZW; // Set LZW compression
            tiffOptions.DpiX = 200u; // Set horizontal DPI
            tiffOptions.DpiY = 200u; // Set vertical DPI

            // Save the presentation as TIFF with the specified options
            pres.Save(outputPath, SaveFormat.Tiff, (TiffOptions)tiffOptions);

            // Dispose the presentation
            pres.Dispose();
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