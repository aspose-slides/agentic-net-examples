using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

namespace ShadowEffectExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to the slide
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                50, 50, 200, 100);

            // Create a preset shadow effect using the EffectFactory
            Aspose.Slides.Effects.EffectFactory effectFactory = new Aspose.Slides.Effects.EffectFactory();
            Aspose.Slides.Effects.IPresetShadow presetShadow = effectFactory.CreatePresetShadow();

            // Configure the preset shadow (choose a preset type)
            presetShadow.Preset = Aspose.Slides.PresetShadowType.TopLeftDropShadow;

            // Apply the preset shadow effect to the shape
            shape.EffectFormat.PresetShadowEffect = presetShadow;

            // Save the presentation
            presentation.Save("ShadowEffectPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}