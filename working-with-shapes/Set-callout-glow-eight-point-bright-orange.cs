using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace GlowEffectExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a callout shape to the first slide
            ISlide slide = presentation.Slides[0];
            IAutoShape callout = slide.Shapes.AddAutoShape(ShapeType.Callout1, 100, 100, 300, 150);

            // Enable glow effect
            callout.EffectFormat.EnableGlowEffect();

            // Set glow radius to 8 points
            callout.EffectFormat.GlowEffect.Radius = 8.0;

            // Set glow color to bright orange
            callout.EffectFormat.GlowEffect.Color.Color = Color.FromArgb(255, 165, 0);

            // Define output file path
            string outputPath = "GlowCallout.pptx";

            try
            {
                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }
            finally
            {
                // Dispose presentation
                presentation.Dispose();
            }
        }
    }
}