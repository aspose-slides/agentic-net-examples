using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Path to the source PDF file
            string pdfPath = "document.pdf";

            // Import PDF pages as slides
            Aspose.Slides.ISlide[] addedSlides = presentation.Slides.AddFromPdf(pdfPath);

            // Save the resulting presentation
            string outputPath = "fromPdfDocument.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}