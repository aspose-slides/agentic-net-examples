using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Ensure output directory exists
        string outputDir = "Output";
        if (!System.IO.Directory.Exists(outputDir))
            System.IO.Directory.CreateDirectory(outputDir);

        // Save the presentation as PPTX
        string pptxPath = System.IO.Path.Combine(outputDir, "presentation.pptx");
        presentation.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Save the presentation as PDF
        string pdfPath = System.IO.Path.Combine(outputDir, "presentation.pdf");
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
        presentation.Save(pdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Dispose the presentation
        presentation.Dispose();
    }
}