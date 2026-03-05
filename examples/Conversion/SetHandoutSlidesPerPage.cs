using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the source PPTX presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Create PDF export options with handout layout settings
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            Aspose.Slides.Export.HandoutLayoutingOptions handoutLayout = new Aspose.Slides.Export.HandoutLayoutingOptions();
            handoutLayout.Handout = Aspose.Slides.Export.HandoutType.Handouts4Horizontal; // Set slides per page
            pdfOptions.SlidesLayoutOptions = handoutLayout;

            // Export the presentation to PDF using the handout layout
            pres.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Save the original presentation before exiting
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}