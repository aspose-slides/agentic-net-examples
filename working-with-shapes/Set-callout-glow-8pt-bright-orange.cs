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
                presentation.Save("CalloutGlow.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
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