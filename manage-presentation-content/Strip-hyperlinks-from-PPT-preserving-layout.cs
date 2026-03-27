using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace StripHyperlinks
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            // Remove all hyperlinks
            presentation.HyperlinkQueries.RemoveAllHyperlinks();
            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            // Release resources
            presentation.Dispose();

            Console.WriteLine("All hyperlinks removed. Saved to: " + outputPath);
        }
    }
}