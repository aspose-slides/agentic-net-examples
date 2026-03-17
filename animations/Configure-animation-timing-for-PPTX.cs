using System;
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.Animation;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    // Get the animation timeline for the current slide
                    Aspose.Slides.IAnimationTimeLine timeline = presentation.Slides[slideIndex].Timeline;

                    // Access the main sequence of effects
                    Aspose.Slides.Animation.ISequence mainSequence = timeline.MainSequence;

                    // Adjust timing for each effect in the main sequence
                    for (int effectIndex = 0; effectIndex < mainSequence.Count; effectIndex++)
                    {
                        Aspose.Slides.Animation.IEffect effect = mainSequence[effectIndex];

                        // Set a delay of 0.5 seconds after the trigger
                        effect.Timing.TriggerDelayTime = 0.5f; // seconds

                        // Set the duration of the effect to 2 seconds
                        effect.Timing.Duration = 2.0f; // seconds
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}