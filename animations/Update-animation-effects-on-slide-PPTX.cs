using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Presentation presentation = new Presentation(inputPath))
            {
                // Get the target slide (first slide)
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Access the main animation sequence of the slide
                Aspose.Slides.Animation.ISequence mainSequence = slide.Timeline.MainSequence;

                // Remove any existing effects
                mainSequence.Clear();

                // Get the first shape on the slide to animate
                Aspose.Slides.IShape shape = slide.Shapes[0];

                // Add a Fade effect to the shape with AfterPrevious trigger
                mainSequence.AddEffect(
                    shape,
                    Aspose.Slides.Animation.EffectType.Fade,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                // Retrieve the newly added effect and modify its after-animation behavior
                Aspose.Slides.Animation.IEffect addedEffect = mainSequence[0];
                addedEffect.AfterAnimationType = Aspose.Slides.Animation.AfterAnimationType.HideOnNextMouseClick;

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}