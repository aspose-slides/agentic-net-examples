using System;
using System.IO;

namespace PresentationConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input files: either from command line arguments or predefined list
            string[] inputFiles;
            if (args.Length > 0)
            {
                inputFiles = args;
            }
            else
            {
                inputFiles = new string[] { "Sample.ppt", "Sample.pptx" };
            }

            foreach (string inputPath in inputFiles)
            {
                // Load the presentation (PPT or PPTX)
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Configure advanced PDF export options
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                pdfOptions.JpegQuality = 90; // High-quality JPEG images
                pdfOptions.SaveMetafilesAsPng = true; // Convert metafiles to PNG
                pdfOptions.TextCompression = Aspose.Slides.Export.PdfTextCompression.Flate; // Compress text
                pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.Pdf15; // PDF/A-1b compliance
                pdfOptions.ShowHiddenSlides = true; // Include hidden slides in the PDF

                // Determine output PDF file name
                string outputPath = Path.ChangeExtension(inputPath, ".pdf");

                // Save the presentation as PDF with the specified options
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

                // Release resources
                presentation.Dispose();
            }
        }
    }
}