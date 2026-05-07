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
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Configure TIFF options with custom DPI
            Aspose.Slides.Export.TiffOptions options = new Aspose.Slides.Export.TiffOptions();
            options.DpiX = 150;
            options.DpiY = 150;

            // Save the presentation as TIFF using the specified options
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, options);

            // Ensure the presentation is saved before exiting
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