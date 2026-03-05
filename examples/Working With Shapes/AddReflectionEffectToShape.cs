using System;
using Aspose.Slides;
using Aspose.Slides.Effects;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle shape to the first slide
        Aspose.Slides.IShape shape = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

        // Enable reflection effect on the shape
        shape.EffectFormat.EnableReflectionEffect();

        // Customize reflection properties
        Aspose.Slides.Effects.IReflection reflection = shape.EffectFormat.ReflectionEffect;
        reflection.Distance = 5.0;
        reflection.BlurRadius = 2.0;
        reflection.RotateShadowWithShape = true;

        // Save the presentation before exiting
        presentation.Save("ReflectionEffect.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}