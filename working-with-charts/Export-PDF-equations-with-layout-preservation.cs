using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pdf";

            using (var presentation = new Presentation(inputPath))
            {
                var pdfOptions = new PdfOptions();
                pdfOptions.EmbedFullFonts = true;
                pdfOptions.DefaultRegularFont = "Arial";

                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}