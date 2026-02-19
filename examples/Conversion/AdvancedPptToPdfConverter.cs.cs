using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPT file
            string inputPptPath = Path.Combine(Directory.GetCurrentDirectory(), "Sample.ppt");
            // Input PPTX file
            string inputPptxPath = Path.Combine(Directory.GetCurrentDirectory(), "Sample.pptx");
            // Output PDF for PPT
            string outputPdfFromPpt = Path.Combine(Directory.GetCurrentDirectory(), "Sample_From_PPT.pdf");
            // Output PDF for PPTX
            string outputPdfFromPptx = Path.Combine(Directory.GetCurrentDirectory(), "Sample_From_PPTX.pdf");

            // Create PDF options with advanced features
            PdfOptions pdfOptions = new PdfOptions();
            pdfOptions.EmbedFullFonts = true;
            pdfOptions.Compliance = PdfCompliance.PdfA1b;
            pdfOptions.DrawSlidesFrame = false;
            pdfOptions.SaveMetafilesAsPng = true;
            pdfOptions.ShowHiddenSlides = true;
            pdfOptions.BestImagesCompressionRatio = true;

            // Convert PPT to PDF
            using (Presentation presPpt = new Presentation(inputPptPath))
            {
                presPpt.Save(outputPdfFromPpt, SaveFormat.Pdf, pdfOptions);
            }

            // Convert PPTX to PDF
            using (Presentation presPptx = new Presentation(inputPptxPath))
            {
                presPptx.Save(outputPdfFromPptx, SaveFormat.Pdf, pdfOptions);
            }
        }
    }
}