// -----------------------------------------------------------------------------
// Example: Export paragraph to HTML using method using C#
//
// Description:
// Demonstrates how to export paragraphs from a shape to HTML using the
// ExportToHtml method in Aspose.Slides for .NET. The example loads a PPTX file,
// locates the first AutoShape with a TextFrame, extracts all its paragraphs,
// converts them to HTML, and writes the result to a file. It also saves the
// presentation after processing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, HTML, Export, Paragraph, Method,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate conversion of slide text paragraphs to HTML.
// - Build C# utilities for extracting and publishing slide content.
// - Integrate paragraph-to-HTML transformation in .NET applications.
// - Validate and preview presentation text in web-friendly format.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputHtmlPath = "paragraph.html";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Find the first AutoShape that contains a TextFrame
                IAutoShape textShape = null;
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    if (slide.Shapes[shapeIndex] is IAutoShape)
                    {
                        textShape = (IAutoShape)slide.Shapes[shapeIndex];
                        if (textShape.TextFrame != null)
                        {
                            break;
                        }
                    }
                }

                if (textShape == null || textShape.TextFrame == null)
                {
                    Console.WriteLine("No text shape found in the presentation.");
                }
                else
                {
                    // Export all paragraphs of the shape to HTML
                    IParagraphCollection paragraphs = textShape.TextFrame.Paragraphs;
                    string html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
                    File.WriteAllText(outputHtmlPath, html);
                    Console.WriteLine("Paragraph HTML exported to " + outputHtmlPath);
                }

                // Save the presentation before exiting
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
