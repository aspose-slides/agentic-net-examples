using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPptxToOdp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";
            // Output ODP file path
            string outputPath = "output.odp";

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

                // Save as ODP format
                presentation.Save(outputPath, SaveFormat.Odp);

                // Ensure presentation is saved before exit
                presentation.Dispose();

                Console.WriteLine("Presentation successfully exported to ODP.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The requested format is not supported by Aspose.Slides.
                Console.WriteLine("The ODP format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}