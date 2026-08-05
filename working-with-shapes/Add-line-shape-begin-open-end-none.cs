// -----------------------------------------------------------------------------
// Example: Add line shape begin open end none using C#
//
// Description:
// Demonstrates how to add a line shape with an open arrowhead at the beginning
// and no arrowhead at the end using C# and Aspose.Slides for .NET. The example
// creates a presentation, inserts a line shape, configures its line format,
// and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Line Shape, Arrowhead, Begin Open, End None, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding line shapes with specific arrowhead styles.
// - Build C# tools for customizing PowerPoint line graphics.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate line shape configurations before publishing presentations.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Presentation pres = new Presentation();
            ISlide slide = pres.Slides[0];
            IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
            line.LineFormat.Style = LineStyle.ThickBetweenThin;
            line.LineFormat.Width = 10;
            line.LineFormat.DashStyle = LineDashStyle.DashDot;
            line.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
            line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Open;
            line.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
            line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
            line.LineFormat.FillFormat.FillType = FillType.Solid;
            line.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;
            string outputPath = "LineShape.pptx";
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
