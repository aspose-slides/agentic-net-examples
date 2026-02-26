using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DefaultFontDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a rectangle shape with some text to the first slide
            IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.AddTextFrame("Sample text using default font");

            // Define save options with a default regular font
            PdfOptions pdfOptions = new PdfOptions();
            pdfOptions.DefaultRegularFont = "Arial";

            // Save the presentation using the defined default font
            presentation.Save("DefaultFontPresentation.pdf", SaveFormat.Pdf, pdfOptions);

            // Clean up
            presentation.Dispose();
        }
    }
}