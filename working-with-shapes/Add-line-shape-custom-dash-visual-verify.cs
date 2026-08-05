// -----------------------------------------------------------------------------
// Example: Add line shape custom dash visual verify using C#
//
// Description:
// Demonstrates how to add a line shape with a custom dash pattern, set its
// width and color, and save the presentation using C# and Aspose.Slides for .NET.
// The example illustrates the required presentation‑processing steps for
// PowerPoint files and produces a PPTX file that can be visually verified.
// Developers can use this pattern to automate PPTX workflows, validate results,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Line, Shape, Custom Dash,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding line shapes with custom dash styles.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate visual appearance of custom dash lines before publishing.
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
        var pres = new Presentation();

        // Get the first slide
        var slide = pres.Slides[0];

        // Add a line shape to the slide
        var line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 100, 100, 400, 0);

        // Set line width
        line.LineFormat.Width = 5;

        // Set custom dash style and pattern
        line.LineFormat.DashStyle = LineDashStyle.Custom;
        line.LineFormat.CustomDashPattern = new float[] { 5, 2, 1, 2 }; // dash, gap, dash, gap

        // Set line color
        line.LineFormat.FillFormat.FillType = FillType.Solid;
        line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

        // Save the presentation
        var outputPath = "CustomDashLine.pptx";
        pres.Save(outputPath, SaveFormat.Pptx);
    }
}
