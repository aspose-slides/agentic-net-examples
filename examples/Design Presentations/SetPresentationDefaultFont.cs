using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Configure PDF save options to use Arial as the default font
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.DefaultRegularFont = "Arial";

            // Save the presentation as PDF with the specified default font
            presentation.Save("PresentationWithArial.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
        }
    }
}