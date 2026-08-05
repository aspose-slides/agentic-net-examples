// -----------------------------------------------------------------------------
// Example: Set callout glow 8pt bright orange using C#
//
// Description:
// Demonstrates how to add a callout shape to a slide and apply an 8‑point
// bright orange glow effect using C# and Aspose.Slides for .NET. The example
// creates a new presentation, inserts a Callout1 auto‑shape, enables the glow
// effect, configures its radius and color, and saves the result as a PPTX file.
// This pattern can be used to automate visual styling of callouts in PowerPoint
// presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Callout, Glow, Bright, Orange,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate the addition of callout shapes with a specific glow style.
// - Build C# utilities for styling PowerPoint presentations programmatically.
// - Generate or modify PPTX files with custom visual effects in .NET apps.
// - Validate and preview presentation formatting before distribution.
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
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a callout shape (using Callout1 as ShapeType.Callout does not exist)
            IAutoShape callout = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Callout1,
                50, 50, 300, 100);

            // Enable glow effect
            callout.EffectFormat.EnableGlowEffect();

            // Set glow radius to 8 points
            callout.EffectFormat.GlowEffect.Radius = 8.0;

            // Set glow color to bright orange
            callout.EffectFormat.GlowEffect.Color.Color = Color.Orange;

            // Save the presentation
            try
            {
                presentation.Save("CalloutGlow.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other save errors
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
