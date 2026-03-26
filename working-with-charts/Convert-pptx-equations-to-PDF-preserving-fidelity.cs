using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Configure PDF options for high fidelity (PDF/A-2a compliance)
            PdfOptions pdfOptions = new PdfOptions();
            pdfOptions.Compliance = PdfCompliance.PdfA2a;

            // Save the presentation as PDF
            presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

            // Release resources
            presentation.Dispose();

            Console.WriteLine("Conversion completed successfully.");
        }
    }
}