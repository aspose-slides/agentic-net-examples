using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddInnerShadowEffect
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the existing presentation
                Presentation presentation = new Presentation("input.pptx");

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Get the first shape on the slide (ensure it exists)
                IShape shape = slide.Shapes[0];

                // Enable inner shadow effect for the shape
                shape.EffectFormat.EnableInnerShadowEffect();

                // Configure inner shadow properties
                shape.EffectFormat.InnerShadowEffect.BlurRadius = 5.0;
                shape.EffectFormat.InnerShadowEffect.Distance = 3.0;
                shape.EffectFormat.InnerShadowEffect.Direction = 45.0f;

                // Set shadow color (requires System.Drawing)
                shape.EffectFormat.InnerShadowEffect.ShadowColor.Color = Color.Black;

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}