// -----------------------------------------------------------------------------
// Example: Apply outer shadow 4pt blur 45deg semi transparent black using C#
//
// Description:
// Demonstrates how to apply an outer shadow with a 4 pt blur radius, 45° direction,
// and semi‑transparent black color to a rectangle shape using C# and Aspose.Slides for .NET.
// The example creates a new presentation, adds a rectangle, configures the shadow,
// and saves the result as a PPTX file in a standalone console application.
// Developers can use this pattern to automate PPTX workflows, validate results,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Outer, Shadow, Blur,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying an outer shadow with specific blur, direction, and transparency.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);

        // Set solid fill color (white)
        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 255, 255, 255);

        // Enable outer shadow effect
        shape.EffectFormat.EnableOuterShadowEffect();

        // Configure outer shadow: blur radius 4, direction 45°, distance 5, semi‑transparent black
        shape.EffectFormat.OuterShadowEffect.BlurRadius = 4.0;
        shape.EffectFormat.OuterShadowEffect.Direction = 45.0f;
        shape.EffectFormat.OuterShadowEffect.Distance = 5.0;
        shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.FromArgb(128, 0, 0, 0);

        // Save the presentation
        try
        {
            presentation.Save("OuterShadowExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Handle unsupported format or other errors
        }
    }
}
