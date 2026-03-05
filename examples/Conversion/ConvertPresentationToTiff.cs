using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertToTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check for input and output file arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ConvertToTiff <input-ppt-or-pptx> <output-tiff>");
                return;
            }

            // Input presentation file (PPT or PPTX)
            string inputPath = args[0];
            // Output TIFF file
            string outputPath = args[1];

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation and save it as a multi-page TIFF
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Save the presentation to TIFF format
                presentation.Save(outputPath, SaveFormat.Tiff);
            }

            Console.WriteLine("Conversion completed: " + outputPath);
        }
    }
}