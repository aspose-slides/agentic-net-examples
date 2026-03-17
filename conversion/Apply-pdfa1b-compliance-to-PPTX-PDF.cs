using System;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input PPTX file path
                string inputPath = "input.pptx";
                // Output PDF file path
                string outputPath = "output.pdf";

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Create PDF export options
                    Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                    // Set PDF/A‑1b compliance
                    pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.PdfA1b;

                    // Save as PDF with the specified options
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