using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MathToPdfConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Create PDF options (default options preserve layout, including math equations)
                    Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

                    // Save the presentation as PDF
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
                }

                Console.WriteLine("Presentation successfully converted to PDF: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during conversion: " + ex.Message);
            }
        }
    }
}