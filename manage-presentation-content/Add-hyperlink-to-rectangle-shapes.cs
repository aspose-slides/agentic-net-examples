// -----------------------------------------------------------------------------
// Example: Add hyperlink to rectangle shapes using C#
//
// Description:
// Demonstrates how to add an external hyperlink to rectangle AutoShape objects
// in a PowerPoint presentation using Aspose.Slides for .NET. The example loads
// an existing PPTX file, iterates through its slides and shapes, identifies
// rectangle shapes, assigns a click hyperlink, and saves the modified file.
// This pattern can be used to programmatically enrich presentations with
// navigation or external web links.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Hyperlink, Rectangle, AutoShape, Shapes,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically add external web links to rectangle shapes in PPTX files.
// - Automate hyperlink insertion during presentation generation or editing.
// - Build .NET tools for bulk updating of PowerPoint content.
// - Ensure consistent hyperlink application across multiple slides.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate through all slides
                foreach (ISlide slide in presentation.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        // Cast to AutoShape to check the shape type
                        IAutoShape autoShape = shape as IAutoShape;
                        if (autoShape != null && autoShape.ShapeType == ShapeType.Rectangle)
                        {
                            // Add an external hyperlink to the rectangle shape
                            IHyperlinkManager hyperlinkMgr = autoShape.HyperlinkManager;
                            hyperlinkMgr.SetExternalHyperlinkClick("https://example.com");
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Handle unsupported file format
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., web service errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
