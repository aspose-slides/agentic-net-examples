using System;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Get the first shape on the slide
        Aspose.Slides.IShape shape = slide.Shapes[0];

        // Retrieve the effective effect formatting data (includes inherited effects)
        Aspose.Slides.IEffectFormatEffectiveData effectiveEffect = shape.EffectFormat.GetEffective();

        // Check if a preset shadow effect is applied
        if (effectiveEffect.PresetShadowEffect != null)
        {
            // Get the effective preset shadow data
            Aspose.Slides.Effects.IPresetShadowEffectiveData presetShadow = effectiveEffect.PresetShadowEffect;

            // Output shadow properties
            Console.WriteLine("Preset shadow color: " + presetShadow.ShadowColor);
            Console.WriteLine("Preset shadow distance: " + presetShadow.Distance);
            Console.WriteLine("Preset shadow direction: " + presetShadow.Direction);
            Console.WriteLine("Preset shadow type: " + presetShadow.Preset);
        }
        else
        {
            Console.WriteLine("No preset shadow effect applied.");
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}