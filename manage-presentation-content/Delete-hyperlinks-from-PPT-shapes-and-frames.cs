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

            // Load the presentation, remove all hyperlinks, and save the result
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Remove all hyperlinks from slides, shapes, and frames
                presentation.HyperlinkQueries.RemoveAllHyperlinks();

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            Console.WriteLine("Hyperlinks removed and presentation saved to: " + outputPath);
        }
    }
}