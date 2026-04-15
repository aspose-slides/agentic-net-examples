using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GlowEffectExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a callout shape (using Callout1 as an example)
                Aspose.Slides.IShape callout = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Callout1,
                    100,   // X position
                    100,   // Y position
                    300,   // Width
                    150);  // Height

                // Enable glow effect
                callout.EffectFormat.EnableGlowEffect();

                // Set glow radius to 8 points
                callout.EffectFormat.GlowEffect.Radius = 8.0;

                // Set glow color to bright orange
                callout.EffectFormat.GlowEffect.Color.Color = Color.Orange;

                // Save the presentation
                presentation.Save("GlowCallout.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format, file I/O issues)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}