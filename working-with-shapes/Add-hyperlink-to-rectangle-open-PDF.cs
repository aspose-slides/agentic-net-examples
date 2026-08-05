// -----------------------------------------------------------------------------
// Example: Add hyperlink to rectangle open PDF using C#
//
// Description:
// Demonstrates how to add a hyperlink to a rectangle shape that opens a local
// PDF file using C# and Aspose.Slides for .NET. The example creates a new
// presentation, inserts a rectangle on the first slide, assigns a hyperlink
// pointing to the specified PDF, and saves the result as a PPTX file. This
// pattern can be used to automate PowerPoint workflows that require linking
// to external documents.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Hyperlink, Rectangle,
// Open, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding hyperlinks to shapes that open PDF files.
// - Build C# tools for PowerPoint presentation processing with external links.
// - Generate or transform PPTX files that reference local documents.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

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
