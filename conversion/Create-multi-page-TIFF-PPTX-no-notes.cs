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

        // Verify that the input PPTX file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation from the specified file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Create TiffOptions with default settings (default compression, no notes)
            Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();

            // Save the presentation as a multi‑page TIFF file
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);

            // Release resources used by the presentation
            presentation.Dispose();

            Console.WriteLine("TIFF file created successfully at: " + outputPath);
        }
        catch (NotSupportedException ex)
        {
            // Handle case where the format is not supported
            Console.WriteLine("Format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}