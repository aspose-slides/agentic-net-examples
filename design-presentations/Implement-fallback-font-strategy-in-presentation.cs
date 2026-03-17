using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FallbackFontDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle shape that will contain text
                IAutoShape textShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                textShape.AddTextFrame("Sample text with missing font");

                // Access the first portion of the text and set a non‑existent font
                IPortion portion = textShape.TextFrame.Paragraphs[0].Portions[0];
                portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("NonExistentFont");

                // Configure PDF save options with a fallback font
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.DefaultRegularFont = "Arial";

                // Save the presentation as PDF using the fallback font
                presentation.Save("FallbackFontDemo.pdf", SaveFormat.Pdf, pdfOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}