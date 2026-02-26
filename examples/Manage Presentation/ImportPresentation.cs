using System;
using System.IO;
using Aspose.Slides;

namespace AsposeSlidesImportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input PDF, input HTML and output presentations
            System.String pdfPath = "input.pdf";
            System.String pptxFromPdfPath = "output_from_pdf.pptx";
            System.String htmlPath = "input.html";
            System.String finalPptxPath = "final_output.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Import slides from PDF
            presentation.Slides.AddFromPdf(pdfPath);
            // Save the presentation after PDF import
            presentation.Save(pptxFromPdfPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Import slides from HTML (insert at the beginning, do not use existing slide as start)
            System.IO.FileStream htmlStream = new System.IO.FileStream(htmlPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            presentation.Slides.InsertFromHtml(0, htmlStream, false);
            htmlStream.Close();

            // Save the final presentation containing both PDF and HTML slides
            presentation.Save(finalPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}