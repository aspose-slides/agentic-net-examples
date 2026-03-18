using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

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

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Find the shape by its alternative text
                IShape targetShape = SlideUtil.FindShape(slide, "TargetShapeAltText");

                // Add a Fade animation effect to the shape
                IEffect effect = slide.Timeline.MainSequence.AddEffect(
                    targetShape,
                    Aspose.Slides.Animation.EffectType.Fade,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                // Configure additional animation properties
                effect.AnimateTextType = Aspose.Slides.Animation.AnimateTextType.ByLetter;
                effect.AfterAnimationType = Aspose.Slides.Animation.AfterAnimationType.HideOnNextMouseClick;

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