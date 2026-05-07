using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPptxToPdf
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
                    // Configure PDF options for high quality and vector graphics retention
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.SaveMetafilesAsPng = false; // Preserve metafiles as vectors
                    pdfOptions.JpegQuality = 100; // Maximum JPEG quality for raster images

                    // Save the presentation as PDF using the configured options
                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                }

                Console.WriteLine("Presentation successfully exported to PDF: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}