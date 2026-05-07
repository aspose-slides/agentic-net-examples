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

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Configure TIFF options with 600 DPI for high‑resolution printing
            TiffOptions tiffOptions = new TiffOptions();
            tiffOptions.DpiX = 600;
            tiffOptions.DpiY = 600;

            // Export the presentation to a multi‑page TIFF file
            presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);

            // Release resources
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}