// -----------------------------------------------------------------------------
// Example: Add hyperlink to first slide text using C#
//
// Description:
// Demonstrates how to add a hyperlink to the text of a shape on the first
// slide using C# and Aspose.Slides for .NET. The example creates a new
// presentation, inserts a rectangle shape with a text frame, assigns a
// clickable hyperlink to the text run, and saves the result as a PPTX file.
// This pattern can be used to automate hyperlink insertion in PowerPoint
// presentations within .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hyperlink, First Slide, Text,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding hyperlinks to specific text in a PowerPoint slide.
// - Build C# tools for enriching presentations with interactive links.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate hyperlink functionality in presentation workflows before publishing.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle auto shape on the first slide
        Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 50);

        // Add a text frame with display text
        shape.AddTextFrame("Visit Aspose");

        // Set a website hyperlink on the text run
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick =
            new Aspose.Slides.Hyperlink("https://www.aspose.com");

        // Save the presentation
        string outputPath = "HyperlinkPresentation.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}
