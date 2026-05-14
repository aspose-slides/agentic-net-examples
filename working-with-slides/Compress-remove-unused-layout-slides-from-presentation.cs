using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file names
        string inputFileName = "input.pptx";
        string outputFileName = "output.pptx";

        // Build full paths
        string inputPath = Path.Combine(Environment.CurrentDirectory, inputFileName);
        string outputPath = Path.Combine(Environment.CurrentDirectory, outputFileName);

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Remove all unused layout slides
            Compress.RemoveUnusedLayoutSlides(presentation);

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}