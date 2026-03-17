using System;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the PPTX presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Configure PDF conversion options
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                pdfOptions.JpegQuality = 90;
                pdfOptions.SaveMetafilesAsPng = true;
                pdfOptions.TextCompression = Aspose.Slides.Export.PdfTextCompression.Flate;
                pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.Pdf15;
                pdfOptions.ShowHiddenSlides = true;

                // Save the presentation as PDF
                presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}