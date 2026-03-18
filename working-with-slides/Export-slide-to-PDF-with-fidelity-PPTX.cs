using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPdfPath = "slide1.pdf";
            int slideNumber = 1; // 1‑based index of the slide to convert

            using (Presentation presentation = new Presentation(inputPath))
            {
                // Save the presentation before exiting (no modifications made)
                presentation.Save("temp_save.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

                int[] slides = new int[] { slideNumber };
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.JpegQuality = 90;
                pdfOptions.SaveMetafilesAsPng = true;

                presentation.Save(outputPdfPath, slides, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}