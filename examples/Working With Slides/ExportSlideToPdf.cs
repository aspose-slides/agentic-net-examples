using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportSlideToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the PPTX presentation from file
            Presentation presentation = new Presentation("input.pptx");

            // Create PDF export options (optional, can be customized)
            PdfOptions pdfOptions = new PdfOptions();

            // Save the entire presentation as a PDF file
            presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

            // Dispose the presentation object to release resources
            presentation.Dispose();
        }
    }
}