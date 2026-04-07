using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FooterToXpsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input file path and output directory as arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: FooterToXpsExample <input-pptx> <output-directory>");
                return;
            }

            string inputPath = args[0];
            string outputDir = args[1];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string outputPath = Path.Combine(outputDir, "PresentationWithFooter.xps");

            try
            {
                // Load presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Set footer text for all slides, master, layouts, notes, etc.
                    presentation.HeaderFooterManager.SetAllFootersText("Sample Footer Text");

                    // Save as XPS document
                    presentation.Save(outputPath, SaveFormat.Xps);
                }
            }
            catch (Exception ex)
            {
                // Handle format not supported or other errors
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}