// -----------------------------------------------------------------------------
// Example: Set hyperlink color using custom RGB using C#
//
// Description:
// Demonstrates how to create a new presentation, add a rectangle shape with a
// text frame, assign an external hyperlink to the text, and set a custom
// hyperlink color using an RGB solid fill (red) via Aspose.Slides for .NET.
// The example includes saving the presentation to a PPTX file and proper
// resource cleanup.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Hyperlink, RGB, Custom Color,
// FillType.Solid, Presentation Automation, Office Automation
//
// Use Cases:
// - Apply custom RGB colors to hyperlinks in generated PowerPoint slides.
// - Build .NET utilities that programmatically style hyperlink text.
// - Automate creation of PPTX files with branded hyperlink colors.
// - Validate hyperlink formatting in presentation processing pipelines.
// -----------------------------------------------------------------------------
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a rectangle shape to the first slide
        IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
            ShapeType.Rectangle, 100, 100, 400, 50);

        // Add a text frame with hyperlink text
        shape.AddTextFrame("Click Here");

        // Set external hyperlink on the text portion
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick =
            new Hyperlink("https://www.example.com");

        // Use portion format as the source for hyperlink color
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource =
            HyperlinkColorSource.PortionFormat;

        // Set custom font height
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;

        // Set custom hyperlink color (red) via solid fill
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 0, 0);

        // Save the presentation
        try
        {
            presentation.Save("HyperlinkColor.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other save errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }

        // Ensure resources are released
        presentation.Dispose();
    }
}
