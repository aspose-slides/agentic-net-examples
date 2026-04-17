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
            // Input and output file paths
            string inputPath = "input.odp";
            string outputPath = "output.pdf";

            // Verify that the input file exists
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
                    // Configure PDF options to enable font substitution
                    PdfOptions pdfOptions = new PdfOptions();
                    // Set a default font to be used when the original font is not found
                    pdfOptions.DefaultRegularFont = "Arial";

                    // Define the slide indices to export (3 to 7, 1‑based indexing)
                    int[] slideIndices = new int[] { 3, 4, 5, 6, 7 };

                    // Save selected slides as PDF with the specified options
                    presentation.Save(outputPath, slideIndices, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors, licensing issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}