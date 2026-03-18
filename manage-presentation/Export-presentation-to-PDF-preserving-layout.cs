using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Determine input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pdf";

            // Load the presentation (supports any supported source format)
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Configure PDF export options for high fidelity
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                pdfOptions.JpegQuality = 90; // high JPEG quality
                pdfOptions.SaveMetafilesAsPng = true; // preserve vector graphics
                pdfOptions.TextCompression = Aspose.Slides.Export.PdfTextCompression.Flate;
                pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.Pdf15;

                // Save the presentation as PDF
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}