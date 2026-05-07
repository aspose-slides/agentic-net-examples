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
            // Input and output file paths
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
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Create PDF options (default options flatten annotations)
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

                // Save the presentation as PDF with the specified options
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

                // Release resources
                pres.Dispose();

                Console.WriteLine("Presentation exported to PDF successfully.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
                // format not supported
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}