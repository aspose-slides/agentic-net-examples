// -----------------------------------------------------------------------------
// Example: Add ellipse diagonal pattern fill to pptx using C#
//
// Description:
// Demonstrates how to add an ellipse shape with a diagonal pattern fill to a
// PPTX file using C# and Aspose.Slides for .NET. The example creates a new
// presentation, inserts an ellipse, applies a downward diagonal pattern fill,
// and saves the result. This can be used in console applications for
// automating PowerPoint presentation processing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ellipse, Diagonal, Pattern,
// Fill, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding ellipse diagonal pattern fill to PPTX files.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with patterned shapes in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PatternEllipseDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add an ellipse shape
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Ellipse,
                100,   // X position
                100,   // Y position
                300,   // Width
                200);  // Height

            // Set fill to pattern
            shape.FillFormat.FillType = Aspose.Slides.FillType.Pattern;

            // Configure pattern fill: diagonal lines
            shape.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.DownwardDiagonal;
            shape.FillFormat.PatternFormat.BackColor.Color = Color.White;
            shape.FillFormat.PatternFormat.ForeColor.Color = Color.Black;

            // Prepare output path
            string outputDir = "Output";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }
            string outPath = Path.Combine(outputDir, "PatternEllipse.pptx");

            // Save the presentation with exception handling for unsupported formats
            try
            {
                pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
        }
    }
}
