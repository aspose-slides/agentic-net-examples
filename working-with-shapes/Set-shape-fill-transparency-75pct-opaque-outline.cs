// -----------------------------------------------------------------------------
// Example: Set shape fill transparency 75pct opaque outline using C#
//
// Description:
// Demonstrates how to set a shape's fill to 75% transparency while keeping the
// outline fully opaque using C# and Aspose.Slides for .NET. The example creates a
// new presentation, adds a rectangle shape, applies a semi‑transparent solid fill,
// sets an opaque solid outline, and saves the result as a PPTX file. This pattern
// can be used to automate PowerPoint presentation styling in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Shape, Fill, Transparency,
// 75Pct, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting shape fill transparency to 75% with an opaque outline.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

            // Set fill to solid color with 75% transparency (alpha = 64)
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = Color.FromArgb(64, Color.Blue);

            // Ensure the outline (line) is fully opaque
            shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

            // Save the presentation
            try
            {
                presentation.Save("SetTransparency_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
        }
    }
}
