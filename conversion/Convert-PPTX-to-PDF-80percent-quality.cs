using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptxToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Set PDF options with JPEG quality at 80%
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.JpegQuality = 80;

                // Save the presentation as PDF with the specified options
                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other possible exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}