using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveHyperlinksExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input and output file paths as command line arguments
            if (args == null || args.Length < 2)
            {
                Console.WriteLine("Usage: RemoveHyperlinksExample <input-pptx> <output-pptx>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Remove all hyperlinks while keeping text formatting
            presentation.HyperlinkQueries.RemoveAllHyperlinks();

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();

            Console.WriteLine("Hyperlinks removed and presentation saved to: " + outputPath);
        }
    }
}