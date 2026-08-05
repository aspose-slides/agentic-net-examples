// -----------------------------------------------------------------------------
// Example: Add group shape three ellipses shades lock using C#
//
// Description:
// Demonstrates how to create a group shape containing three ellipses with
// solid fill colors (red, green, blue) and lock their position, size, and
// selection using C# and Aspose.Slides for .NET. The example shows the required
// presentation‑processing steps for PowerPoint files and produces the
// requested output in a standalone console application. Developers can use
// this pattern to automate PPTX workflows, enforce shape locking, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Group, Shape, Ellipse, Fill,
// Lock, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of grouped ellipses with locked properties.
// - Build C# tools for PowerPoint presentation processing that require shape
//   protection.
// - Generate or transform PPTX files with predefined locked graphics in .NET
//   applications.
// - Validate presentation workflows involving grouped shapes before publishing
//   or integration.
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
        var pres = new Presentation();
        var slide = pres.Slides[0];

        // Add a group shape to the slide
        var group = slide.Shapes.AddGroupShape();

        // First ellipse
        var ellipse1 = group.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
        ellipse1.FillFormat.FillType = FillType.Solid;
        ellipse1.FillFormat.SolidFillColor.Color = Color.Red;
        ellipse1.ShapeLock.PositionLocked = true;
        ellipse1.ShapeLock.SizeLocked = true;
        ellipse1.ShapeLock.SelectLocked = true;

        // Second ellipse
        var ellipse2 = group.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);
        ellipse2.FillFormat.FillType = FillType.Solid;
        ellipse2.FillFormat.SolidFillColor.Color = Color.Green;
        ellipse2.ShapeLock.PositionLocked = true;
        ellipse2.ShapeLock.SizeLocked = true;
        ellipse2.ShapeLock.SelectLocked = true;

        // Third ellipse
        var ellipse3 = group.Shapes.AddAutoShape(ShapeType.Ellipse, 350, 50, 100, 100);
        ellipse3.FillFormat.FillType = FillType.Solid;
        ellipse3.FillFormat.SolidFillColor.Color = Color.Blue;
        ellipse3.ShapeLock.PositionLocked = true;
        ellipse3.ShapeLock.SizeLocked = true;
        ellipse3.ShapeLock.SelectLocked = true;

        // Save the presentation
        var outPath = "GroupEllipses.pptx";
        try
        {
            pres.Save(outPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}
