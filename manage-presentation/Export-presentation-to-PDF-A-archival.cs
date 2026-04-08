using System;
using System.IO;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Aspose.Slides.Presentation(inputPath);

                // Set PDF options with PDF/A compliance
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.PdfA2a;

                // Save as PDF
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // TODO: handle unsupported format
            }
            finally
            {
                // Ensure the presentation is saved and resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}