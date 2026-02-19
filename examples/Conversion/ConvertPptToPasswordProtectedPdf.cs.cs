using System;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input PowerPoint file, output PDF file, and PDF password
            string inputFile = "input.pptx";
            string outputFile = "output.pdf";
            string pdfPassword = "MySecurePassword";

            // Load the presentation from the input file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile);

            // Create PDF options and set the password
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.Password = pdfPassword;

            // Save the presentation as a password‑protected PDF
            presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}