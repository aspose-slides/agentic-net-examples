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
            string outputPptxPath = "output.pptx";
            string outputPdfPath = "output.pdf";

            using (Presentation presentation = new Presentation(inputPath))
            {
                // Export to PPTX format
                presentation.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Export to PDF format preserving layout fidelity
                PdfOptions pdfOptions = new PdfOptions();
                presentation.Save(outputPdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}