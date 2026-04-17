using System;
using System.IO;
using Aspose.Slides.Export;

namespace ConvertPptToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            var inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            var outputPath = Path.Combine(Environment.CurrentDirectory, "output.pdf");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                using (var presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Set PDF options to include hidden slides
                    var pdfOptions = new Aspose.Slides.Export.PdfOptions();
                    pdfOptions.ShowHiddenSlides = true;

                    // Save as PDF with the specified options
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported.
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}