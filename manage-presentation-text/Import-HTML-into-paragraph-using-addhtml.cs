// -----------------------------------------------------------------------------
// Example: Import HTML into paragraph using AddFromHtml using C#
//
// Description:
// Demonstrates how to import HTML content into a paragraph of a shape using
// the AddFromHtml method in Aspose.Slides for .NET. The example creates a new
// presentation, adds a rectangle shape, clears default paragraphs, imports
// HTML into the shape's text frame, and saves the result as a PPTX file.
// This pattern can be used to automate HTML-to-PowerPoint conversion in .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, HTML, Import, AddFromHtml, Paragraph, Shape, Presentation Processing, Office Automation
//
// Use Cases:
// - Convert HTML snippets into PowerPoint slide content.
// - Build .NET tools that embed formatted HTML into presentations.
// - Automate generation of PPTX files from web content.
// - Validate HTML rendering within PowerPoint slides.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HtmlImportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input HTML file and output presentation paths
            string inputHtmlPath = "input.html";
            string outputPresentationPath = "output.pptx";

            // Verify that the input HTML file exists
            if (!File.Exists(inputHtmlPath))
            {
                Console.WriteLine("Input HTML file does not exist: " + inputHtmlPath);
                return;
            }

            try
            {
                // Read the HTML content from the file
                string htmlContent;
                using (StreamReader reader = new StreamReader(inputHtmlPath))
                {
                    htmlContent = reader.ReadToEnd();
                }

                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape to host the text
                IAutoShape shape = slide.Shapes.AddAutoShape(
                    ShapeType.Rectangle,
                    50,   // X position
                    50,   // Y position
                    500,  // Width
                    300   // Height
                );

                // Make the shape transparent
                shape.FillFormat.FillType = FillType.NoFill;

                // Add an empty text frame to the shape
                shape.AddTextFrame(string.Empty);

                // Clear any default paragraphs
                shape.TextFrame.Paragraphs.Clear();

                // Import the HTML content into the paragraph collection
                shape.TextFrame.Paragraphs.AddFromHtml(htmlContent);

                // Save the presentation
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully to: " + outputPresentationPath);
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
