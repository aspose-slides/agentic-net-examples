using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPTX file and output PDF file paths
        var inputPath = "input.pptx";
        var outputPath = "output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Convert and save the presentation to PDF using default options
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);

            // Release resources
            presentation.Dispose();

            Console.WriteLine("Conversion completed successfully.");
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