// -----------------------------------------------------------------------------
// Example: Modify hyperlink URL after creation using C#
//
// Description:
// Demonstrates how to modify a hyperlink URL after it has been created on a
// text portion within a shape using C# and Aspose.Slides for .NET. The example
// creates a new presentation, adds a rectangle with a text frame, assigns an
// initial hyperlink, then replaces it with a new hyperlink and updates the
// tooltip. The presentation is saved as a PPTX file, illustrating a typical
// workflow for mutable hyperlink handling in automated PowerPoint processing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Modify, Hyperlink, After,
// Creation, Presentation Processing, Office Automation, HyperlinkClick
//
// Use Cases:
// - Programmatically update hyperlink URLs in existing PowerPoint content.
// - Build C# utilities that need to adjust links after initial creation.
// - Automate PPTX generation where link destinations may change during runtime.
// - Validate and test hyperlink behavior in presentation workflows.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a rectangle shape with a text frame
            Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 50, false);
            shape.AddTextFrame("Click here");

            // Set the initial hyperlink
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick =
                new Aspose.Slides.Hyperlink("http://example.com");
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Initial link";

            // Modify the hyperlink URL by assigning a new Hyperlink object
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick =
                new Aspose.Slides.Hyperlink("https://newexample.org");
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Updated link";

            // Save the presentation
            presentation.Save("MutableHyperlinkDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
