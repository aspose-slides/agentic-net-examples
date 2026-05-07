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
        string outputPath = "output.pdf";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Convert to PDF using default settings
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);

            // Release resources
            pres.Dispose();

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (NotSupportedException)
        {
            // Handle unsupported format
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}