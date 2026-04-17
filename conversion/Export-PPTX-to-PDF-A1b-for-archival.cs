using System;
using System.IO;
using Aspose.Slides.Export;

namespace ExportPptxToPdfA1b
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            string inputPath = "sample.pptx";
            string outputDirectory = "output";
            string outputPath = Path.Combine(outputDirectory, "sample.pdf");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            try
            {
                // Load presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Set PDF options with PDF/A‑1b compliance
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.PdfA1b;

                // Save as PDF/A‑1b
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

                // Dispose presentation
                presentation.Dispose();

                Console.WriteLine("Presentation successfully exported to PDF/A‑1b: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}