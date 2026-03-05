using System;

class Program
{
    static void Main()
    {
        // Load the PPTX presentation
        using (var presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Create PdfOptions for conversion
            var pdfOptions = new Aspose.Slides.Export.PdfOptions();

            // Save the presentation as PDF
            presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
        }
    }
}