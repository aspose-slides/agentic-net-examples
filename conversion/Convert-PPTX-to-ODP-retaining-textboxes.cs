using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPTX file and output ODP file paths
        string inputPath = "input.pptx";
        string outputPath = "output.odp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation from the PPTX file
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Save the presentation as ODP format
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Odp);

            // Release resources
            pres.Dispose();

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (NotSupportedException)
        {
            // Handle unsupported format exception
            Console.WriteLine("The file format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            // Handle any other exceptions
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}