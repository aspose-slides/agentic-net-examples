// -----------------------------------------------------------------------------
// Example: Reset shape formatting before applying visual effects
//
// Description:
// Demonstrates how to reset all shape formatting on the first slide of a PPTX
// file before applying an outer shadow effect to a shape using Aspose.Slides for .NET.
// The program creates a sample presentation if none exists, resets formatting,
// applies the effect, and saves the result.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Reset shape formatting, Outer shadow, Visual effects
//
// Use Cases:
// - Ensure consistent shape styling before adding visual effects in automated PPTX workflows.
// - Programmatically apply shadow effects after clearing previous formatting.
// - Build .NET tools for presentation styling and effect management.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;

class Program
{
    static int Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            try
            {
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
                {
                    Aspose.Slides.ISlide slide = pres.Slides[0];
                    Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);
                    shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
                    pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create sample input: " + ex.Message);
                return 1;
            }
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                slide.Reset();

                Aspose.Slides.IShape firstShape = slide.Shapes[0];
                firstShape.EffectFormat.EnableOuterShadowEffect();
                firstShape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
                firstShape.EffectFormat.OuterShadowEffect.Distance = 3.0;
                firstShape.EffectFormat.OuterShadowEffect.Direction = 45;
                firstShape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.FromArgb(0, 0, 0);

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Format not supported.");
            return 1;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return 1;
        }

        return 0;
    }
}
