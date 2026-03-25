using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Presentation presentation = new Presentation(inputPath);

        // Convert and save the presentation as PDF
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);

        // Release resources
        presentation.Dispose();

        Console.WriteLine("Conversion to PDF completed successfully.");
    }
}