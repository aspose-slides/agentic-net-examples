using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Configure default regular font for saving
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
        pdfOptions.DefaultRegularFont = "Arial Black";

        // Save the presentation with the specified default font
        presentation.Save("DefaultFontPresentation.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
    }
}