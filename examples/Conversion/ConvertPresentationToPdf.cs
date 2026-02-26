using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load the PowerPoint presentation
        Presentation presentation = new Presentation("input.pptx");

        // Create PDF export options
        PdfOptions pdfOptions = new PdfOptions();
        pdfOptions.JpegQuality = 90;
        pdfOptions.SaveMetafilesAsPng = true;
        pdfOptions.TextCompression = PdfTextCompression.Flate;
        pdfOptions.Compliance = PdfCompliance.Pdf15;

        // Save the presentation as PDF with the custom options
        presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

        // Release resources
        presentation.Dispose();
    }
}