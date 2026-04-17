using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the local PDF file
            string pdfPath = "C:\\Docs\\sample.pdf";

            // Verify that the PDF file exists
            if (!File.Exists(pdfPath))
            {
                Console.WriteLine("PDF file does not exist: " + pdfPath);
                return;
            }

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a rectangle shape to the first slide
            IAutoShape rectangle = (IAutoShape)presentation.Slides[0].Shapes.AddAutoShape(
                ShapeType.Rectangle, 100, 100, 300, 100);
            rectangle.AddTextFrame("Open PDF");

            // Set an external hyperlink on the rectangle to open the PDF file
            rectangle.HyperlinkManager.SetExternalHyperlinkClick(pdfPath);

            // Save the presentation
            string outputPath = "HyperlinkRectangle.pptx";
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle errors such as unsupported format
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}