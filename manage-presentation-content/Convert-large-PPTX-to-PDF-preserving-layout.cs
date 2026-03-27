using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "large_presentation.pptx";
        string outputPath = "large_presentation.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Export to PDF preserving all content and layout
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);

        // Release resources
        pres.Dispose();

        Console.WriteLine("Export completed successfully.");
    }
}