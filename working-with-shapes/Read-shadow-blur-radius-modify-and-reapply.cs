// -----------------------------------------------------------------------------
// Example: Read shadow blur radius modify and reapply using C#
//
// Description:
// Demonstrates how to read the blur radius of an outer shadow effect on a shape,
// modify the radius, and reapply the updated effect using Aspose.Slides for .NET.
// The example loads a PPTX file, accesses the first shape on the first slide,
// enables the outer shadow effect if necessary, adjusts the blur radius, and
// saves the modified presentation. This pattern can be used to automate
// shadow styling adjustments in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Read, Shadow, Blur, Radius,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate reading and adjusting shadow blur radius in presentations.
// - Build C# tools for PowerPoint visual effect customization.
// - Generate or transform PPTX files with updated shadow properties.
// - Validate and fine‑tune presentation aesthetics before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

namespace ShadowEffectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Get the first shape (assumed to be an AutoShape)
                IAutoShape shape = (IAutoShape)slide.Shapes[0];

                // Access the effect format of the shape
                IEffectFormat effectFormat = shape.EffectFormat;

                // Ensure outer shadow effect is enabled
                effectFormat.EnableOuterShadowEffect();

                // Get the outer shadow effect
                IOuterShadow outerShadow = effectFormat.OuterShadowEffect;

                // Read current blur radius
                double currentBlur = outerShadow.BlurRadius;

                // Modify blur radius (increase by 5 points)
                outerShadow.BlurRadius = currentBlur + 5.0;

                // Save the updated presentation
                pres.Save(outputPath, SaveFormat.Pptx);

                // Clean up
                pres.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}
