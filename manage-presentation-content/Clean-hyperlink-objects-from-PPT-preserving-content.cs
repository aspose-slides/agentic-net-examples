using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveHyperlinksDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Remove all hyperlinks from the presentation
            presentation.HyperlinkQueries.RemoveAllHyperlinks();

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();

            Console.WriteLine("All hyperlinks have been removed. Saved to: " + outputPath);
        }
    }
}