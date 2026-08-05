// -----------------------------------------------------------------------------
// Example: Reset shape formatting before visual effects using C#
//
// Description:
// Demonstrates how to reset all shape formatting on a slide before applying
// visual effects using Aspose.Slides for .NET. The example loads a PPTX file,
// resets formatting of shapes on the first slide, applies an outer shadow
// effect to the first shape, and saves the result. This pattern helps
// developers ensure consistent formatting when programmatically adding
// effects to PowerPoint presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Reset, Shape, Formatting,
// Visual Effects, Outer Shadow, Presentation Processing, Office Automation
//
// Use Cases:
// - Reset shape formatting before applying visual effects in automated PPTX workflows.
// - Add or modify visual effects such as shadows to shapes after clearing prior formatting.
// - Build .NET tools for consistent presentation styling and effect application.
// - Validate and transform PowerPoint files programmatically before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Reset formatting of all shapes on the slide (including the target shape)
                slide.Reset();

                // Example: work with the first shape on the slide
                Aspose.Slides.IShape shape = slide.Shapes[0];

                // Apply a new visual effect: enable outer shadow
                shape.EffectFormat.EnableOuterShadowEffect();
                shape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
                shape.EffectFormat.OuterShadowEffect.Distance = 3.0;
                shape.EffectFormat.OuterShadowEffect.Direction = 45;
                shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = System.Drawing.Color.FromArgb(0, 0, 0);

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported.
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
