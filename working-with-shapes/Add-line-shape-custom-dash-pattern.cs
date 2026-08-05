// -----------------------------------------------------------------------------
// Example: Add line shape custom dash pattern using C#
//
// Description:
// Demonstrates how to add a line shape with a custom dash pattern, custom
// line style, arrowheads, and solid fill color using C# and Aspose.Slides for
// .NET. The example creates a new presentation, inserts a line shape on the
// first slide, configures its line formatting, and saves the result as a PPTX
// file. This pattern can be used to automate PowerPoint line styling tasks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Line Shape, Custom Dash Pattern,
// Line Formatting, Arrowheads, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding line shapes with custom dash patterns to presentations.
// - Build C# tools for styling lines in PowerPoint files.
// - Generate or modify PPTX files with specific line aesthetics in .NET
//   applications.
// - Validate line formatting before publishing or integration.
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
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a line shape
        IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

        // Set line style and width
        line.LineFormat.Style = LineStyle.ThickBetweenThin;
        line.LineFormat.Width = 10;

        // Set custom dash pattern
        line.LineFormat.DashStyle = LineDashStyle.Custom;
        line.LineFormat.CustomDashPattern = new float[] { 5f, 2f, 1f, 2f };

        // Set arrowheads
        line.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
        line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;
        line.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
        line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

        // Set line fill color
        line.LineFormat.FillFormat.FillType = FillType.Solid;
        line.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

        // Save the presentation
        string outputPath = "CustomDashLine.pptx";
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other save errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}
