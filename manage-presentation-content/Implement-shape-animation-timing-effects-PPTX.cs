using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace ShapeAnimationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "AnimatedPresentation.pptx");

            // Create a new presentation
            var presentation = new Presentation();

            // Add two rectangle shapes to the first slide
            var shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 150, 100);
            var shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 250, 100, 150, 100);

            // Add FadedZoom effects with different subtypes
            var effect1 = presentation.Slides[0].Timeline.MainSequence.AddEffect(
                shape1,
                EffectType.FadedZoom,
                EffectSubtype.ObjectCenter,
                EffectTriggerType.OnClick);

            var effect2 = presentation.Slides[0].Timeline.MainSequence.AddEffect(
                shape2,
                EffectType.FadedZoom,
                EffectSubtype.SlideCenter,
                EffectTriggerType.OnClick);

            // Configure timing: repeat until end of slide and enable rewind for the first effect
            effect1.Timing.RepeatUntilEndSlide = true;
            effect1.Timing.Rewind = true;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}