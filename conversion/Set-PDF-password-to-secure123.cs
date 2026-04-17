using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            var inputPath = args.Length > 0 ? args[0] : "input.pptx";
            var outputPath = "output.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file '{inputPath}' does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                var presentation = new Presentation(inputPath);

                // Set PDF options with password protection
                var pdfOptions = new PdfOptions();
                pdfOptions.Password = "Secure123";

                // Save as password‑protected PDF
                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine($"PDF saved successfully to '{outputPath}'.");
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Format not supported comment
                // Note: If the exception is due to an unsupported format, handle accordingly.
            }
        }
    }
}