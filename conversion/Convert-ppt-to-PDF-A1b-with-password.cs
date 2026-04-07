using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesPdfConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            string inputFileName = "input.pptx";
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Set PDF options: password protection and PDF/A-1b compliance
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                pdfOptions.Password = "openPassword";
                pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.PdfA1b;

                // Prepare output directory and file path
                string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "output");
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }
                string outputFileName = "output.pdf";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Save the presentation as PDF with the specified options
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

                // Dispose the presentation object
                presentation.Dispose();

                Console.WriteLine("Presentation converted to PDF successfully.");
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                // Format not supported
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}