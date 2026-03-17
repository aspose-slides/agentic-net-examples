using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace AnimationToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Presentation presentation = new Presentation("input.pptx");

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Ensure there is at least one shape to animate
                if (slide.Shapes.Count > 0)
                {
                    IShape shape = slide.Shapes[0];

                    // Add a Fade animation effect with AfterPrevious trigger
                    slide.Timeline.MainSequence.AddEffect(
                        shape,
                        EffectType.Fade,
                        EffectSubtype.None,
                        EffectTriggerType.AfterPrevious);
                }

                // Save the presentation as PDF (animations are retained in the export)
                presentation.Save("output.pdf", SaveFormat.Pdf);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}