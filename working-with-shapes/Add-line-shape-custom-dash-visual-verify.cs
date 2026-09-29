// -----------------------------------------------------------------------------
// Example: Add Custom Dash Line Shape to PowerPoint using Aspose.Slides
//
// Description:
// This console application creates a new PPTX file, adds a line shape with a
// custom dash pattern, sets its width and color, and saves the presentation.
// It demonstrates the use of Aspose.Slides for .NET to automate PowerPoint
// generation and visual verification of line formatting.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, line shape, custom dash, line width, shape color
//
// Use Cases:
// - Automate creation of presentation templates with styled line graphics.
// - Validate visual appearance of line formatting in generated PPTX files.
// - Integrate line shape generation into .NET reporting or documentation tools.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

namespace AsposeSlidesLineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "CustomDashLine.pptx";

            try
            {
                // Ensure output directory exists
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outputDir) && !Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a line shape (auto shape) to the slide
                Aspose.Slides.IAutoShape lineShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Line,
                    100,   // X position
                    100,   // Y position
                    400,   // Width of the line
                    0      // Height (0 for a horizontal line)
                );

                // Configure line formatting
                lineShape.LineFormat.Style = Aspose.Slides.LineStyle.ThickThin;
                lineShape.LineFormat.Width = 5; // Line width in points
                lineShape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dash; // Custom dash pattern
                lineShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                lineShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                Console.WriteLine($"Presentation saved successfully to '{outputPath}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
