using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Presentation presentation = new Presentation(inputPath))
            {
                // Select the slide to modify (e.g., first slide)
                ISlide slide = presentation.Slides[0];

                // Get the main animation sequence of the slide
                ISequence mainSequence = slide.Timeline.MainSequence;

                // Store existing effects
                System.Collections.Generic.List<IEffect> effects = new System.Collections.Generic.List<IEffect>();
                for (int i = 0; i < mainSequence.Count; i++)
                {
                    effects.Add(mainSequence[i]);
                }

                // Clear current effects
                mainSequence.Clear();

                // Re-add effects in reverse order to change playback sequence
                for (int i = effects.Count - 1; i >= 0; i--)
                {
                    IEffect originalEffect = effects[i];
                    IShape shape = originalEffect.TargetShape;

                    // Add effect with the same type and subtype, using AfterPrevious trigger
                    mainSequence.AddEffect(
                        shape,
                        originalEffect.Type,
                        originalEffect.Subtype,
                        EffectTriggerType.AfterPrevious);
                }

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