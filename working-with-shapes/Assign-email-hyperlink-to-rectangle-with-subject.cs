// -----------------------------------------------------------------------------
// Example: Assign email hyperlink to rectangle with subject using C#
//
// Description:
// Demonstrates how to assign an email hyperlink with a predefined subject line
// to a rectangle shape in a PowerPoint presentation using C# and Aspose.Slides
// for .NET. The example creates a new presentation, adds a rectangle shape with
// a text frame, sets a mailto hyperlink with a subject on the text portion, and
// saves the presentation as a PPTX file. This pattern can be used to automate
// hyperlink assignment in PPTX files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Assign, Email, Hyperlink,
// Rectangle, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate assigning email hyperlinks with subjects to shapes in presentations.
// - Build C# tools for PowerPoint automation and hyperlink management.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate presentation hyperlink functionality before distribution.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle shape to the first slide
        Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 50);

        // Add a text frame with display text
        shape.AddTextFrame("Contact Us");

        // Define the mailto hyperlink with a predefined subject line
        string mailto = "mailto:someone@example.com?subject=Inquiry";

        // Assign the hyperlink to the portion text
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Aspose.Slides.Hyperlink(mailto);

        // Save the presentation before exiting
        presentation.Save("EmailHyperlink.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
