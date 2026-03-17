using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();

            // Access the first slide (read-only property usage is allowed)
            var slide = presentation.Slides[0];

            // Save as PPTX with default PPTX options
            var pptxOptions = new Aspose.Slides.Export.PptxOptions();
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx, pptxOptions);

            // Save as PDF with default PDF options
            var pdfOptions = new Aspose.Slides.Export.PdfOptions();
            presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}