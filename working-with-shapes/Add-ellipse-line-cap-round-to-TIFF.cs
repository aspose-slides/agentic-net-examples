// -----------------------------------------------------------------------------
// Example: Add ellipse line cap round to TIFF using C#
//
// Description:
// Demonstrates how to create an ellipse shape with a round line cap and a
// glow effect, then save the presentation as a TIFF image using C# and
// Aspose.Slides for .NET. The example shows the required presentation-processing
// steps for PowerPoint files and produces the requested output in a standalone
// console application. Developers can use this pattern to automate PPTX workflows,
// apply shape styling, or integrate image export functionality into .NET apps.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ellipse, Line Cap, Round, Glow,
// TIFF, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding an ellipse with round line caps and glow to a presentation.
// - Build C# tools for PowerPoint shape styling and image export.
// - Generate TIFF images from PPTX files in .NET applications.
// - Validate shape formatting before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddEllipseLineCapRoundToTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add an ellipse shape
                    IAutoShape ellipse = slide.Shapes.AddAutoShape(
                        ShapeType.Ellipse, 100, 100, 300, 200);

                    // Set line cap style to round
                    ellipse.LineFormat.CapStyle = LineCapStyle.Round;

                    // Enable and configure glow effect
                    ellipse.EffectFormat.EnableGlowEffect();
                    ellipse.EffectFormat.GlowEffect.Radius = 5.0;

                    // Save the presentation as TIFF
                    presentation.Save("EllipseWithGlow.tiff", SaveFormat.Tiff);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
