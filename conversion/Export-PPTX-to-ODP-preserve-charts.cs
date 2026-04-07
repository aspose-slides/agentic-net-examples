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
        string outputPath = "output.odp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation from the PPTX file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Save the presentation as ODP, preserving embedded charts
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Odp);

            // Dispose the presentation before exiting
            presentation.Dispose();

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other possible exceptions (e.g., I/O errors, external resources)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}