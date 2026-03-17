using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace AnimationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Presentation presentation = new Presentation("input.pptx");

                // Locate the first shape on the first slide
                IShape shape = presentation.Slides[0].Shapes[0];

                // Add a Fade effect to the shape with AfterPrevious trigger
                IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(
                    shape,
                    Aspose.Slides.Animation.EffectType.Fade,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                // Set effect duration (in seconds) and start delay (in seconds)
                effect.Timing.Duration = 2.0f;          // 2 seconds duration
                effect.Timing.TriggerDelayTime = 1.0f; // 1 second start delay

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}