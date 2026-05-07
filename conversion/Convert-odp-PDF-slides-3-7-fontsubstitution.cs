using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertOdpToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.odp";
            string outputPath = "output.pdf";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the ODP presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Enable font substitution by setting a default regular font
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.DefaultRegularFont = "Arial";

                    // Define the slide range (3 to 7, 1‑based indexing)
                    int[] slideIndices = new int[] { 3, 4, 5, 6, 7 };

                    // Save selected slides as PDF
                    presentation.Save(outputPath, slideIndices, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Comment: format not supported
            }
        }
    }
}