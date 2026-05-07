using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
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
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Configure TiffOptions with high DPI and custom image size
                Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
                tiffOptions.DpiX = 300; // Horizontal DPI
                tiffOptions.DpiY = 300; // Vertical DPI
                tiffOptions.ImageSize = new Size(2550, 3300); // Example size for 8.5"x11" at 300 DPI

                // Save the presentation as TIFF with the specified options
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            // Handle format not supported or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
            // If the exception is due to unsupported format, you can add specific handling here
        }
    }
}