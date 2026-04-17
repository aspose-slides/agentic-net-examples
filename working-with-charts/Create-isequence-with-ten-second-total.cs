using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        var outputPath = "CustomSequence.pptx";

        using (var presentation = new Presentation())
        {
            var slide = presentation.Slides[0];

            // Ensure the slide has at least one shape before accessing it
            var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.TextFrame.Text = "Animated Shape";

            // Get the main animation sequence
            var mainSequence = slide.Timeline.MainSequence;

            // Add three effects to the main sequence
            var effect1 = mainSequence.AddEffect(shape, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.AfterPrevious);
            var effect2 = mainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
            var effect3 = mainSequence.AddEffect(shape, EffectType.Zoom, EffectSubtype.In, EffectTriggerType.AfterPrevious);

            // Distribute a total duration of 10 seconds (10000 ms) among the effects
            // Assuming the Timing object has a Duration property in milliseconds
            effect1.Timing.Duration = 3000;
            effect2.Timing.Duration = 3000;
            effect3.Timing.Duration = 4000;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}