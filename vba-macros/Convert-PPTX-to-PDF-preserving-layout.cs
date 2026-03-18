using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            using (Presentation presentation = new Presentation(inputPath))
            {
                PdfOptions pdfOptions = new PdfOptions();
                // Example options to preserve quality
                pdfOptions.JpegQuality = 90;
                pdfOptions.SaveMetafilesAsPng = true;
                pdfOptions.TextCompression = PdfTextCompression.Flate;

                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}