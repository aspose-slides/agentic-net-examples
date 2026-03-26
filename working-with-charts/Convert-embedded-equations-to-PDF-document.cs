using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input PowerPoint file containing mathematical equations
        string inputPath = "input.pptx";
        // Output PDF file
        string outputPath = "output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Save the presentation as PDF, preserving equation rendering
        presentation.Save(outputPath, SaveFormat.Pdf);

        // Release resources
        presentation.Dispose();

        Console.WriteLine("Conversion completed successfully.");
    }
}