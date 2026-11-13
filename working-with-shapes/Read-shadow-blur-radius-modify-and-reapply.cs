// -----------------------------------------------------------------------------
// Example: Read and Modify Outer Shadow Blur Radius in PowerPoint using C#
//
// Description:
// Demonstrates how to read the blur radius of an outer shadow effect on a shape,
// modify the radius, and reapply the updated effect using Aspose.Slides for .NET.
// The program creates a sample PPTX if none exists, adjusts the shadow blur,
// and saves the result, enabling automation of shadow styling in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Shadow Blur Radius, Outer Shadow
//
// Use Cases:
// - Batch update shadow effects across presentation slides.
// - Ensure consistent visual styling in generated PowerPoint reports.
// - Integrate shadow adjustments into automated slide generation pipelines.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace ShadowEffectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                if (!File.Exists(inputPath))
                {
                    Aspose.Slides.Presentation createPres = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide createSlide = createPres.Slides[0];
                    Aspose.Slides.IAutoShape rect = createSlide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 150);
                    rect.AddTextFrame("Sample Shape");
                    rect.EffectFormat.EnableOuterShadowEffect();
                    createPres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    createPres.Dispose();
                }

                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
                Aspose.Slides.ISlide slide = pres.Slides[0];

                if (slide.Shapes.Count == 0)
                {
                    Console.WriteLine("No shapes found on the first slide.");
                    pres.Dispose();
                    Environment.Exit(1);
                }

                Aspose.Slides.IShape shape = slide.Shapes[0];
                Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                if (autoShape == null)
                {
                    Console.WriteLine("The first shape is not an AutoShape.");
                    pres.Dispose();
                    Environment.Exit(1);
                }

                Aspose.Slides.IEffectFormat effectFormat = autoShape.EffectFormat;
                effectFormat.EnableOuterShadowEffect();

                Aspose.Slides.Effects.IOuterShadow outerShadow = effectFormat.OuterShadowEffect;
                double currentBlur = outerShadow.BlurRadius;
                outerShadow.BlurRadius = currentBlur + 5.0;

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Shadow blur radius updated and saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                // The provided file format may not be supported by Aspose.Slides.
                Environment.Exit(1);
            }
        }
    }
}
