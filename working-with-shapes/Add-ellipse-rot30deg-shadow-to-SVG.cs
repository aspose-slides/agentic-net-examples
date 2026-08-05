// -----------------------------------------------------------------------------
// Example: Add ellipse rot30deg shadow to SVG using C#
//
// Description:
// Demonstrates how to add an ellipse rotated by 30 degrees with an outer
// shadow effect to a slide and export the slide as SVG using C# and
// Aspose.Slides for .NET. The example creates a new presentation, adds the
// shape, applies rotation and shadow, saves the presentation, and writes the
// slide to an SVG file in a standalone console application. Developers can
// use this pattern to automate PPTX workflows, validate results, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SVG, Ellipse, Rot30Deg, Shadow,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding an ellipse with 30° rotation and shadow to a slide.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files and export slides as SVG in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideSvgExport
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define output directory
                string outputDirectory = "Output";
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add an ellipse shape
                IAutoShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 200, 100);

                // Set rotation to 30 degrees
                ellipse.Rotation = 30;

                // Apply outer shadow effect
                ellipse.EffectFormat.EnableOuterShadowEffect();

                // Save the presentation (required before exit)
                string pptxPath = Path.Combine(outputDirectory, "result.pptx");
                presentation.Save(pptxPath, SaveFormat.Pptx);

                // Export the slide as SVG
                string svgPath = Path.Combine(outputDirectory, "slide.svg");
                using (FileStream svgStream = File.Create(svgPath))
                {
                    slide.WriteAsSvg(svgStream);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., file I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
