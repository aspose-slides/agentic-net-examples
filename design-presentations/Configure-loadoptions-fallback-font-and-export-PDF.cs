using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPdfPath = "output.pdf";
            string tempPresentationPath = "temp_output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Configure load options with a fallback regular font
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.DefaultRegularFont = "Arial";

                // Load the presentation using the configured load options
                using (Presentation presentation = new Presentation(inputPath, loadOptions))
                {
                    // Optional: configure PDF options for better text rendering
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.RasterizeUnsupportedFontStyles = true;

                    // Save the presentation as PDF
                    presentation.Save(outputPdfPath, SaveFormat.Pdf, pdfOptions);

                    // Save the presentation before exiting (as required)
                    presentation.Save(tempPresentationPath, SaveFormat.Pptx);
                }

                Console.WriteLine("PDF generated successfully: " + outputPdfPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // If the exception is due to an unsupported file format, the above message will indicate it.
            }
        }
    }
}