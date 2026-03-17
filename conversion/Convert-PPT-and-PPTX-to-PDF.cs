using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Convert PPT to PDF
            string pptPath = "sample.ppt";
            string pdfFromPpt = "sample_from_ppt.pdf";
            Aspose.Slides.Presentation pptPresentation = new Aspose.Slides.Presentation(pptPath);
            pptPresentation.Save(pdfFromPpt, Aspose.Slides.Export.SaveFormat.Pdf);
            pptPresentation.Dispose();

            // Convert PPTX to PDF
            string pptxPath = "sample.pptx";
            string pdfFromPptx = "sample_from_pptx.pdf";
            Aspose.Slides.Presentation pptxPresentation = new Aspose.Slides.Presentation(pptxPath);
            pptxPresentation.Save(pdfFromPptx, Aspose.Slides.Export.SaveFormat.Pdf);
            pptxPresentation.Dispose();

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}