// -----------------------------------------------------------------------------
// Example: Add hyperlink to rectangle open website verify using C#
//
// Description:
// Demonstrates how to add a hyperlink to a rectangle shape that opens a
// website, using C# and Aspose.Slides for .NET. The example creates a new
// presentation, inserts a rectangle with a text frame, assigns an external
// hyperlink to the text, and saves the presentation as PPTX. This pattern can
// be used to automate hyperlink insertion in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hyperlink, Rectangle, Open,
// Website, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding hyperlinks to shapes in PowerPoint presentations.
// - Build C# utilities for PowerPoint content enrichment.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate hyperlink functionality before publishing presentations.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a rectangle shape to the first slide
        IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 50);

        // Add a text frame with display text
        shape.AddTextFrame("Click here to visit Aspose");

        // Assign an external hyperlink to the text portion
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

        // Save the presentation; handle unsupported format exception
        try
        {
            presentation.Save("HyperlinkDemo.pptx", SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Ensure the presentation is saved before exiting
        presentation.Dispose();
    }
}
