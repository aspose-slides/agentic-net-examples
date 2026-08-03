// -----------------------------------------------------------------------------
// Example: Add hyperlink to paragraph portion using C#
//
// Description:
// Demonstrates how to add an external hyperlink to a specific portion of a
// paragraph in a PowerPoint slide using C# and Aspose.Slides for .NET. The
// example creates a new presentation, inserts a rectangle shape with a text
// frame, modifies the first portion's text, assigns a click hyperlink, and
// saves the result as a PPTX file. This pattern can be used to automate
// hyperlink insertion in presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hyperlink, Paragraph, Portion,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically add external hyperlinks to specific text portions.
// - Build tools that enrich PowerPoint content with clickable links.
// - Generate or modify PPTX files in .NET applications.
// - Validate hyperlink functionality in automated presentation workflows.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a rectangle auto shape
            Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 50);

            // Add a text frame
            shape.AddTextFrame("Placeholder");

            // Access the first portion of the first paragraph
            Aspose.Slides.IPortion portion = shape.TextFrame.Paragraphs[0].Portions[0];

            // Set the display text for the portion
            portion.Text = "Aspose.Slides";

            // Get the hyperlink manager for the portion format
            Aspose.Slides.IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;

            // Set an external hyperlink on click using the manager
            hyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com");

            // Save the presentation
            try
            {
                presentation.Save("HyperlinkPortion.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception)
            {
                // Format not supported
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
