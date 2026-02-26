using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPresentationToPdf
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Expect two arguments: input presentation path and output PDF path
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ConvertPresentationToPdf <input-ppt-or-pptx> <output-pdf>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Load the presentation (supports PPT, PPTX, etc.)
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Configure PDF export options with advanced features
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.JpegQuality = 90; // High-quality JPEG images
            pdfOptions.SaveMetafilesAsPng = true; // Convert metafiles to PNG
            pdfOptions.TextCompression = Aspose.Slides.Export.PdfTextCompression.Flate; // Compress text
            pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.Pdf15; // PDF/A-1b compliance
            pdfOptions.Password = "SecretPassword123"; // Protect PDF with a password
            pdfOptions.AccessPermissions = Aspose.Slides.Export.PdfAccessPermissions.PrintDocument |
                                          Aspose.Slides.Export.PdfAccessPermissions.HighQualityPrint;

            // Save the presentation as PDF using the configured options
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Release resources
            presentation.Dispose();

            Console.WriteLine("Conversion completed successfully.");
        }
    }
}