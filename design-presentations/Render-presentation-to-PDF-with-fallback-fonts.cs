using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RenderPresentationToPdf
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
                // Load the presentation with fallback font settings
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.DefaultRegularFont = "Arial";
                using (Presentation presentation = new Presentation(inputPath, loadOptions))
                {
                    // Configure PDF export options with fallback font
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.DefaultRegularFont = "Arial";

                    // Save the presentation as PDF using the correct SaveFormat enum
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
                }

                Console.WriteLine("Presentation successfully rendered to PDF: " + outputPath);
            }
            catch (PptxUnsupportedFormatException)
            {
                // Handle unsupported file format
                Console.WriteLine("The provided file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., network errors, I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}