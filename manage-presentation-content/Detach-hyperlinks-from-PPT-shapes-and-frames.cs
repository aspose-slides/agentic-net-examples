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
        string outputPath = "output.pptx";

        // Override paths with command line arguments if provided
        if (args.Length >= 1)
        {
            inputPath = args[0];
        }
        if (args.Length >= 2)
        {
            outputPath = args[1];
        }

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation
        Presentation presentation = new Presentation(inputPath);

        // Remove all hyperlink associations
        presentation.HyperlinkQueries.RemoveAllHyperlinks();

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();

        Console.WriteLine("All hyperlinks have been removed. Saved to: " + outputPath);
    }
}