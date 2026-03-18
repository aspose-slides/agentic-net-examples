using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var sourcePath = "input.pptx";
            var outputPath = "output.pdf";
            var slideIndex = 0; // zero‑based index of the slide to convert

            using (var sourcePresentation = new Presentation(sourcePath))
            {
                using (var targetPresentation = new Presentation())
                {
                    // Remove the default empty slide from the new presentation
                    targetPresentation.Slides.RemoveAt(0);

                    // Clone the specific slide from the source presentation
                    var sourceSlide = sourcePresentation.Slides[slideIndex];
                    targetPresentation.Slides.InsertClone(0, sourceSlide);

                    // Ensure the slide size matches the original
                    targetPresentation.SlideSize.SetSize(
                        sourcePresentation.SlideSize.Size.Width,
                        sourcePresentation.SlideSize.Size.Height,
                        SlideSizeScaleType.DoNotScale);

                    var pdfOptions = new PdfOptions();

                    // Save the single‑slide presentation as PDF
                    targetPresentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}