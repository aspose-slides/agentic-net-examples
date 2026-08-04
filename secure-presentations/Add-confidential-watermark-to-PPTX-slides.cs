// -----------------------------------------------------------------------------
// Example: Add confidential watermark to PPTX slides using C#
//
// Description:
// Demonstrates how to add a confidential watermark to PPTX slides using C# and 
// Aspose.Slides for .NET. The example creates a new presentation, adds a 
// semi‑transparent diagonal text watermark to the master slide, and saves the 
// result as a PPTX file. Developers can use this pattern to automate watermark 
// insertion, enforce document confidentiality, or integrate presentation 
// processing into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Confidential, Watermark, Slides, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a confidential watermark to PPTX slides.
// - Build C# tools for PowerPoint presentation security.
// - Generate or transform PPTX files with branding or confidentiality marks in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first master slide
        Aspose.Slides.IMasterSlide master = pres.Masters[0];

        // Add a rectangle shape that covers the slide area
        Aspose.Slides.IAutoShape watermarkShape = master.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,
            0,
            0,
            pres.SlideSize.Size.Width,
            pres.SlideSize.Size.Height);

        // Add the watermark text
        watermarkShape.AddTextFrame("Confidential");

        // Center the text within the shape
        watermarkShape.TextFrame.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

        // Make the shape itself invisible
        watermarkShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
        watermarkShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

        // Set semi‑transparent fill for the text
        Aspose.Slides.IPortion portion = watermarkShape.TextFrame.Paragraphs[0].Portions[0];
        portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(128, Color.Red); // 50% transparent red

        // Rotate the shape to appear as a diagonal watermark
        watermarkShape.Rotation = -45;

        // Save the presentation, handling unsupported format exceptions
        try
        {
            pres.Save("WatermarkedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}
