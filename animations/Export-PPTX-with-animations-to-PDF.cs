using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pdf";

                using (Presentation presentation = new Presentation(inputPath))
                {
                    PdfOptions pdfOptions = new PdfOptions();
                    // Include hidden slides to preserve any animation-related content
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