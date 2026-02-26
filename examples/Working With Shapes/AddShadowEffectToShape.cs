using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

namespace AddShadowEffectToShape
{
    class Program
    {
        static void Main(string[] args)
        {
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
                150);  // Height

            // Enable preset shadow effect on the shape
            shape.EffectFormat.EnablePresetShadowEffect();

            // Configure the preset shadow
            shape.EffectFormat.PresetShadowEffect.Preset = Aspose.Slides.PresetShadowType.TopLeftDropShadow;
            shape.EffectFormat.PresetShadowEffect.Distance = 5.0;   // Distance in points
            shape.EffectFormat.PresetShadowEffect.Direction = 45.0f; // Direction in degrees

            // Save the presentation
            pres.Save("AddShadowEffect.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}