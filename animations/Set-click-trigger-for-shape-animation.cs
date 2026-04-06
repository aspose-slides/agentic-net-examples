using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace AnimationTriggerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a rectangle shape to the first slide
            IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

            // Add an animation effect to the shape with OnClick trigger
            IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(
                shape,
                EffectType.Appear,
                EffectSubtype.None,
                EffectTriggerType.OnClick);

            // Save the presentation
            string outputPath = System.IO.Path.Combine(Environment.CurrentDirectory, "AnimationTrigger.pptx");
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}