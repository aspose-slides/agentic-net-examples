using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPT file path and output PDF file path
            string inputFilePath = "input.pptx";
            string outputFilePath = "output.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Read the PPT file into a byte array
            byte[] pptBytes = File.ReadAllBytes(inputFilePath);

            // Load the presentation from the byte array using a memory stream
            using (MemoryStream memoryStream = new MemoryStream(pptBytes))
            {
                try
                {
                    Presentation presentation = new Presentation(memoryStream);

                    // Configure PDF options for PDF/A‑1b compliance (default image quality)
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.Compliance = PdfCompliance.PdfA1b;

                    // Save the presentation as a PDF file
                    presentation.Save(outputFilePath, SaveFormat.Pdf, pdfOptions);

                    // Dispose the presentation object
                    presentation.Dispose();
                }
                catch (NotSupportedException)
                {
                    // Comment: format not supported
                    Console.WriteLine("The provided format is not supported for conversion.");
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., I/O errors)
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
    }
}