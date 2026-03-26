using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check for required arguments: input and output file paths
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ConvertToXps <input-pptx> <output-xps>");
                return;
            }

            // Input and output file paths
            string inputPath = args[0];
            string outputPath = args[1];

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation and convert to XPS format
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Save the presentation as XPS without additional options
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
    }
}