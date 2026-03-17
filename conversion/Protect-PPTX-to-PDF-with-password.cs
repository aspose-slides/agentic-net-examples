using System;
using Aspose.Slides.Export;

namespace AsposeSlidesPdfProtection
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
                // Password to protect the PDF
                string pdfPassword = "password";

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Set PDF options with password protection
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                pdfOptions.Password = pdfPassword;

                // Save the presentation as a password‑protected PDF
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}