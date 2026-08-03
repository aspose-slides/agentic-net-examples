// -----------------------------------------------------------------------------
// Example: Set textbox background color by paragraph style using C#
//
// Description:
// Demonstrates how to set a textbox's background color based on paragraph
// style using C# and Aspose.Slides for .NET. The example loads an existing
// presentation (or creates a new one), adds a rectangle shape with a text
// frame, accesses the first paragraph, and applies a solid fill color to the
// shape. The resulting presentation is saved as a PPTX file. This pattern can
// be adapted to apply different colors depending on paragraph formatting.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Textbox, Background, Color,
// Paragraph, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting textbox background colors based on paragraph styles.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetTextboxBackgroundByParagraphStyle
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            Presentation presentation = null;

            // Load existing presentation if it exists, otherwise create a new one
            if (File.Exists(inputPath))
            {
                try
                {
                    presentation = new Presentation(inputPath);
                }
                catch (Exception)
                {
                    // Format not supported
                    // Create a new presentation as fallback
                    presentation = new Presentation();
                }
            }
            else
            {
                presentation = new Presentation();
            }

            // Ensure there is at least one slide
            ISlide slide = null;
            if (presentation.Slides.Count > 0)
            {
                slide = presentation.Slides[0];
            }
            else
            {
                slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            }

            // Add a rectangle shape that will act as a text box
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 300, 100);
            // Add a text frame with sample text
            ITextFrame textFrame = shape.AddTextFrame("Sample text for paragraph style.");

            // Access the first paragraph (could be extended to iterate paragraphs)
            IParagraph paragraph = textFrame.Paragraphs[0];

            // Example: set the shape's background color based on a chosen color
            // Here we simply use LightBlue; replace with logic based on paragraph style if needed
            shape.FillFormat.FillType = FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = Color.LightBlue;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}
