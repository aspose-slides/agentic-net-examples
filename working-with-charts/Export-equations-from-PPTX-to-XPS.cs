using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportMathToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            string inputPath = "input.pptx";
            // Output XPS file path
            string outputPath = "output.xps";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Save the presentation as XPS preserving formatting
                    pres.Save(outputPath, SaveFormat.Xps);
                }

                Console.WriteLine("Presentation successfully exported to XPS: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}