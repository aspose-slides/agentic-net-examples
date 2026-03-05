using System;
using Aspose.Slides;
using Aspose.Slides.Effects;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Access the first shape on the slide
        Aspose.Slides.IShape shape = slide.Shapes[0];

        // Get the effective effect formatting data for the shape
        Aspose.Slides.IEffectFormatEffectiveData effectiveEffect = shape.EffectFormat.GetEffective();

        // Check if a preset shadow effect is present
        if (effectiveEffect.PresetShadowEffect != null)
        {
            // Retrieve the effective preset shadow data
            Aspose.Slides.Effects.IPresetShadowEffectiveData presetShadow = effectiveEffect.PresetShadowEffect;

            // Output shadow properties
            System.Console.WriteLine("Preset shadow color: " + presetShadow.ShadowColor.ToString());
            System.Console.WriteLine("Preset type: " + presetShadow.Preset.ToString());
            System.Console.WriteLine("Direction: " + presetShadow.Direction);
            System.Console.WriteLine("Distance: " + presetShadow.Distance);
        }
        else
        {
            System.Console.WriteLine("No preset shadow effect applied to the shape.");
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}