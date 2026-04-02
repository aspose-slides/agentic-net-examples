using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first slide (always exists in a new presentation)
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to ensure the shape collection is not empty
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

            // Retrieve the main animation sequence of the slide
            Aspose.Slides.Animation.ISequence mainSequence = slide.Timeline.MainSequence;

            // Add first effect (Fade) – will play after previous (none) with a delay of 5 seconds
            Aspose.Slides.Animation.IEffect effect1 = mainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
            // If the Timing.Duration property is available, set it to 5000 ms (5 seconds)
            // effect1.Timing.Duration = 5000;

            // Add second effect (Fly) – will play after the first effect, also 5 seconds
            Aspose.Slides.Animation.IEffect effect2 = mainSequence.AddEffect(shape, EffectType.Fly, EffectSubtype.None, EffectTriggerType.AfterPrevious);
            // effect2.Timing.Duration = 5000;

            // Save the presentation (handle unsupported format exception)
            try
            {
                presentation.Save("CustomSequence.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (System.ArgumentException)
            {
                // Format not supported
            }
        }
    }
}