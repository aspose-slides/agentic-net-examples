using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HighlightedShapeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "HighlightedShape.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a rectangle shape
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                100,   // X position
                100,   // Y position
                300,   // Width
                200);  // Height

            // Set a solid fill for the rectangle
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(255, 255, 255, 200);

            // Apply outer shadow effect
            shape.EffectFormat.EnableOuterShadowEffect();
            shape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
            shape.EffectFormat.OuterShadowEffect.Direction = 45;
            shape.EffectFormat.OuterShadowEffect.Distance = 5.0;
            shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = System.Drawing.Color.FromArgb(128, 0, 0, 0);

            // Apply glow effect
            shape.EffectFormat.EnableGlowEffect();
            shape.EffectFormat.GlowEffect.Radius = 10.0;

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}