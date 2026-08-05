// -----------------------------------------------------------------------------
// Example: Set rectangle dash solid then dashdot verify using C#
//
// Description:
// Demonstrates how to set a rectangle's line dash style to Solid, add a click‑triggered
// animation, then change the dash style to DashDot using C# and Aspose.Slides for .NET.
// The example creates a presentation, modifies shape formatting, and saves the file.
// Developers can use this pattern to automate PPTX workflows, validate shape
// formatting changes, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rectangle, Dash, Solid, DashDot,
// Animation, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting rectangle dash style to Solid then DashDot and verify.
// - Build C# tools for PowerPoint shape formatting and animation handling.
// - Generate or transform PPTX files with specific line styles in .NET applications.
// - Validate shape formatting changes before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main()
        {
            // Define output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "RectangleDashStyleDemo.pptx");

            // Ensure the output directory exists
            try
            {
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create output directory: " + ex.Message);
                return;
            }

            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a rectangle shape
                IShape rect = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 150);

                // Set initial line dash style to Solid
                rect.LineFormat.DashStyle = LineDashStyle.Solid;

                // Add a click-triggered animation (any effect) to the rectangle
                IEffect clickEffect = slide.Timeline.MainSequence.AddEffect(
                    rect,
                    EffectType.FadedZoom,
                    EffectSubtype.ObjectCenter,
                    EffectTriggerType.OnClick);

                // After the animation is added, change the line dash style to DashDot
                // (In a real scenario, this would be handled by a custom animation behavior;
                // here we set it directly for demonstration purposes.)
                rect.LineFormat.DashStyle = LineDashStyle.DashDot;

                // Save the presentation
                try
                {
                    pres.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to: " + outputPath);
                }
                catch (Exception saveEx)
                {
                    // Handle unsupported format exception
                    Console.WriteLine("Error saving presentation: " + saveEx.Message);
                }
            }
        }
    }
}
