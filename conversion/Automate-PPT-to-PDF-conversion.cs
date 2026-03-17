using System;
using Aspose.Slides.Export;

namespace PresentationConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input PowerPoint file path
                string inputPath = "input.pptx";
                // Output PDF file path
                string outputPath = "output.pdf";

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Create PDF export options (optional)
                    Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                    // Example option: set JPEG quality
                    pdfOptions.JpegQuality = 90;

                    // Save the presentation as PDF
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during conversion
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}