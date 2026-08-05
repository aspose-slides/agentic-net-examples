// -----------------------------------------------------------------------------
// Example: Add line shape theme accent color verify using C#
//
// Description:
// Demonstrates how to add a line shape, assign its line color using a theme
// accent (Accent1), verify the effective color before and after modifying the
// theme's Accent1 color, and save the presentation using Aspose.Slides for .NET.
// The example shows the required presentation-processing steps for PowerPoint
// files and produces the requested output in a standalone console application.
// Developers can use this pattern to automate PPTX workflows, validate results,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Line, Shape, Theme, Accent,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a line shape with theme-based accent color and verify it.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a line shape
            Aspose.Slides.IAutoShape lineShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 50, 300, 0);

            // Set line color using theme Accent1
            lineShape.LineFormat.FillFormat.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Accent1;

            // Verify initial line color (should reflect Accent1)
            Aspose.Slides.ILineFormatEffectiveData effectiveBefore = lineShape.LineFormat.GetEffective();
            Color colorBefore = effectiveBefore.FillFormat.SolidFillColor;
            Console.WriteLine("Line color before theme change: " + colorBefore.ToString());

            // Change the theme's Accent1 color to Green
            presentation.MasterTheme.ColorScheme.Accent1.Color = Color.Green;

            // Verify line color after theme change
            Aspose.Slides.ILineFormatEffectiveData effectiveAfter = lineShape.LineFormat.GetEffective();
            Color colorAfter = effectiveAfter.FillFormat.SolidFillColor;
            Console.WriteLine("Line color after theme change: " + colorAfter.ToString());

            // Save the presentation
            presentation.Save("LineThemeAccent.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (FileNotFoundException ex)
        {
            // Input file not found
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling (including unsupported format)
            // Format not supported.
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
