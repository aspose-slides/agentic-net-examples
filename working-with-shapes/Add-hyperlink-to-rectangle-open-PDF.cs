// -----------------------------------------------------------------------------
// Example: Add hyperlink to rectangle shape to open PDF
//
// Description:
// Demonstrates how to create a new PowerPoint presentation, insert a rectangle
// shape on the first slide, assign a hyperlink that opens a local PDF file, and
// save the result as a PPTX file using Aspose.Slides for .NET. The program also
// creates a placeholder PDF if it does not exist.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Hyperlink, Rectangle
//
// Use Cases:
// - Automate adding hyperlinks to shapes that open PDF documents.
// - Build tools for generating presentations with external document references.
// - Validate presentation workflows that include links to local files.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace HyperlinkExample
{
    class Program
    {
        static int Main(string[] args)
        {
            string pdfPath = "sample.pdf";

            // Ensure the PDF file exists; create a minimal placeholder if missing.
            if (!File.Exists(pdfPath))
            {
                try
                {
                    // Minimal PDF header to make the file recognizable.
                    File.WriteAllBytes(pdfPath, new byte[] { 0x25, 0x50, 0x44, 0x46, 0x2D });
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create placeholder PDF: " + ex.Message);
                    return 1;
                }
            }

            Aspose.Slides.Presentation presentation;
            try
            {
                presentation = new Aspose.Slides.Presentation();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create presentation: " + ex.Message);
                return 1;
            }

            Aspose.Slides.IAutoShape rectangle;
            try
            {
                rectangle = presentation.Slides[0].Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 50);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to add rectangle shape: " + ex.Message);
                return 1;
            }

            try
            {
                rectangle.AddTextFrame("");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to add text frame: " + ex.Message);
                return 1;
            }

            try
            {
                Aspose.Slides.Hyperlink hyperlink = new Aspose.Slides.Hyperlink(pdfPath);
                rectangle.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = hyperlink;
                rectangle.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Open PDF";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to set hyperlink: " + ex.Message);
                return 1;
            }

            try
            {
                presentation.Save("HyperlinkedRectangle.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
                return 1;
            }

            return 0;
        }
    }
}
