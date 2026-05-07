using System;
using System.IO;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main(string[] args)
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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Create TIFF options and set custom image dimensions
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
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other possible exceptions
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}