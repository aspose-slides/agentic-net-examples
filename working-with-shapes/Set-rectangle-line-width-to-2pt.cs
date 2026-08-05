// -----------------------------------------------------------------------------
// Example: Set rectangle line width to 2pt using C#
//
// Description:
// Demonstrates how to create a rectangle shape and set its line width to 2 points
// using C# and Aspose.Slides for .NET. The example creates a new presentation,
// adds a rectangle, configures its fill and line properties (including a 2pt
// line width), retrieves the effective line width, and saves the result as a PPTX
// file. This pattern can be used to automate shape styling in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rectangle, Line Width, Shape Styling,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting rectangle line width to 2pt in presentations.
// - Build C# tools for PowerPoint shape formatting.
// - Generate or modify PPTX files with specific line styling in .NET applications.
// - Validate shape appearance before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define output directory and file
                string outputDir = "Output";
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }
                string outputPath = Path.Combine(outputDir, "RectangleLineWidth.pptx");

                // Create a new presentation
                Presentation pres = new Presentation();

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a rectangle shape
                IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

                // Set shape fill to white
                shape.FillFormat.FillType = FillType.Solid;
                shape.FillFormat.SolidFillColor.Color = Color.White;

                // Configure line format
                shape.LineFormat.Style = LineStyle.ThickThin;
                shape.LineFormat.Width = 2.0; // Set line width to 2 points
                shape.LineFormat.DashStyle = LineDashStyle.Dash;
                shape.LineFormat.FillFormat.FillType = FillType.Solid;
                shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

                // Retrieve effective line width
                ILineFormatEffectiveData effectiveLine = shape.LineFormat.GetEffective();
                double effectiveWidth = effectiveLine.Width;
                Console.WriteLine("Effective line width: " + effectiveWidth);

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
