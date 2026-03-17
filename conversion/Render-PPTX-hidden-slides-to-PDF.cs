using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
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
                    pdfOptions.ShowHiddenSlides = true;

                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}