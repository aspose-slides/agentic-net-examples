// -----------------------------------------------------------------------------
// Example: Add rounded rectangle increase corner radius using C#
//
// Description:
// Demonstrates how to add a rectangle shape and increase its corner radius
// using Aspose.Slides for .NET. The example creates a presentation, adds a
// rectangle shape, checks for a CornerSize adjustment, increments the radius
// by 5 points, and saves the file. This pattern can be used to modify rounded
// corners of shapes programmatically.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rounded Rectangle, Corner Radius,
// Shape Adjustments, Presentation Processing, Office Automation
//
// Use Cases:
// - Increase corner radius of existing rectangle or rounded rectangle shapes.
// - Automate shape styling in PowerPoint presentations.
// - Build .NET tools for adjusting visual properties of PPTX files.
// - Validate shape adjustments before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AdjustRoundedRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory and file
            string outputDir = "Output";
            string outputPath = Path.Combine(outputDir, "RoundedRectangle.pptx");

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a rectangle shape
            IAutoShape rectShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 150);

            // Check if the shape has a CornerSize adjustment and increase its radius by 5 points
            if (rectShape.Adjustments.Count > 0 && rectShape.Adjustments[0].Type == ShapeAdjustmentType.CornerSize)
            {
                rectShape.Adjustments[0].AngleValue += 5;
            }

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation
            pres.Dispose();
        }
    }
}
