using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

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
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Set TIFF conversion options with custom image size
            Aspose.Slides.Export.TiffOptions options = new Aspose.Slides.Export.TiffOptions();
            options.ImageSize = new Size(1024, 768);

            // Save the presentation as TIFF with the specified options
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, options);

            // Dispose the presentation object
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}