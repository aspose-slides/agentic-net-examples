using System;
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
            if (!System.IO.File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Remove all hyperlinks from textual elements while preserving formatting
            presentation.HyperlinkQueries.RemoveAllHyperlinks();

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();

            Console.WriteLine("Hyperlinks removed and presentation saved to: " + outputPath);
        }
    }
}