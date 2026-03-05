using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Import slides from a PDF file
        string pdfPath = "input.pdf";
        string pdfOutputPath = "outputFromPdf.pptx";
        Aspose.Slides.Presentation pdfPresentation = new Aspose.Slides.Presentation();
        pdfPresentation.Slides.AddFromPdf(pdfPath);
        pdfPresentation.Save(pdfOutputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pdfPresentation.Dispose();

        // Import slides from an HTML file
        string htmlPath = "input.html";
        string htmlOutputPath = "outputFromHtml.pptx";
        Aspose.Slides.Presentation htmlPresentation = new Aspose.Slides.Presentation();
        using (FileStream htmlStream = File.OpenRead(htmlPath))
        {
            // Insert HTML content as slides starting at index 0, without using the existing slide as a start point
            htmlPresentation.Slides.InsertFromHtml(0, htmlStream, false);
        }
        htmlPresentation.Save(htmlOutputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        htmlPresentation.Dispose();
    }
}