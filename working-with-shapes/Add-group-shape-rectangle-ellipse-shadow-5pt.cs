// -----------------------------------------------------------------------------
// Example: Add group shape rectangle ellipse shadow 5pt using C#
//
// Description:
// Demonstrates how to add a group shape containing a rectangle and an ellipse,
// apply an outer shadow effect with a 5‑point offset, and save the result as a
// PPTX file using Aspose.Slides for .NET. The example shows the required
// presentation‑processing steps for PowerPoint files and produces the
// requested output in a standalone console application. Developers can use
// this pattern to automate PPTX workflows, validate results, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Group, Shape, Rectangle,
// Ellipse, Shadow, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a grouped rectangle and ellipse with a 5‑point outer shadow.
// - Build C# tools for PowerPoint presentation processing that involve grouped shapes.
// - Generate or transform PPTX files with custom shape effects in .NET applications.
// - Validate presentation workflows that require grouped shapes and shadow styling.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a group shape to the slide
        Aspose.Slides.IGroupShape group = slide.Shapes.AddGroupShape();

        // Add a rectangle inside the group
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

        // Add an ellipse inside the group
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 150, 250, 150, 100);

        // Apply outer shadow effect to the group with an offset (distance) of 5 points
        group.EffectFormat.EnableOuterShadowEffect();
        group.EffectFormat.OuterShadowEffect.Distance = 5;

        // Save the presentation
        string outPath = Path.Combine(Directory.GetCurrentDirectory(), "GroupShapeShadow.pptx");
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}
