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
            string pdfPath = @"C:\Documents\sample.pdf";

            // Verify that the PDF file exists
            if (!File.Exists(pdfPath))
            {
                Console.WriteLine("The specified PDF file does not exist: " + pdfPath);
                return;
            }

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a rectangle shape to the first slide
            IAutoShape rectangle = presentation.Slides[0].Shapes.AddAutoShape(
                ShapeType.Rectangle, 100, 100, 200, 50);

            // Add an empty text frame (required for hyperlink)
            rectangle.AddTextFrame("");

            // Set the hyperlink on the first portion of the first paragraph
            rectangle.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink(pdfPath);

            // Optionally set a tooltip
            rectangle.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Open PDF";

            // Save the presentation
            try
            {
                presentation.Save("HyperlinkedRectangle.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other save errors
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}