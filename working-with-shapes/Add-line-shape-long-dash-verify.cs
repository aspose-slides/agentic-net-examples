// -----------------------------------------------------------------------------
// Example: Add line shape long dash verify using C#
//
// Description:
// Demonstrates how to add a line shape with a long dash (LargeDash) style,
// verify its effective dash style, and save the presentation using C# and
// Aspose.Slides for .NET. The example illustrates the required steps for
// creating a line shape, configuring its line format, retrieving the effective
// formatting, and exporting the result to a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Line, Shape, Long, Dash,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a line shape with a long dash style and verify its properties.
// - Build C# utilities for PowerPoint presentation processing.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate line formatting before publishing or further integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "LineDashStyleDemo.pptx";
        try
        {
            Presentation presentation = new Presentation();
            ISlide slide = presentation.Slides[0];
            // Add a plain line shape
            IAutoShape line = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 100, 300, 0);
            // Set dash style to LargeDash (long dash)
            line.LineFormat.DashStyle = LineDashStyle.LargeDash;
            // Verify visual appearance by outputting the effective dash style
            LineDashStyle effectiveDash = line.LineFormat.GetEffective().DashStyle;
            Console.WriteLine("Effective DashStyle: " + effectiveDash);
            // Save presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
