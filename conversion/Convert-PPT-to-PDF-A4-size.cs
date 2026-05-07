using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToPdf
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
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Set slide size to A4 paper and maximize content scaling
                    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize);

                    // Create PDF options (customize as needed)
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save the presentation as PDF with the specified options
                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                }

                Console.WriteLine("Presentation successfully converted to PDF: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Handle unsupported format exception
                Console.WriteLine("The file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}