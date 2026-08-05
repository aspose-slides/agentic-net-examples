// -----------------------------------------------------------------------------
// Example: Set decorative line fill opacity 70pct verify using C#
//
// Description:
// Demonstrates how to set decorative line fill opacity 70pct verify using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Decorative, Line, Fill, 
// Opacity, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate set decorative line fill opacity 70pct verify.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace LineOpacityExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a rectangle shape (used as decorative line)
            IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 5);

            // Configure line format
            shape.LineFormat.Width = 5;
            shape.LineFormat.Style = LineStyle.ThickThin;
            shape.LineFormat.DashStyle = LineDashStyle.Dash;

            // Set line fill to solid with 70% opacity (alpha = 178 out of 255)
            shape.LineFormat.FillFormat.FillType = FillType.Solid;
            shape.LineFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(178, 0, 0, 255); // Semi-transparent blue

            // Verify effective line format opacity
            ILineFormatEffectiveData effectiveLineFormat = shape.LineFormat.GetEffective();
            ILineFillFormatEffectiveData effectiveFill = effectiveLineFormat.FillFormat;

            // Output effective fill type and color (including alpha)
            Console.WriteLine("Effective Line Fill Type: " + effectiveFill.FillType);
            Console.WriteLine("Effective Line Fill Color (ARGB): " + effectiveFill.SolidFillColor.ToString());

            // Save the presentation
            try
            {
                presentation.Save("LineOpacityDemo.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            finally
            {
                presentation.Dispose();
            }
        }
    }
}
