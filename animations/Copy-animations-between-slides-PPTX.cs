using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace CopyAnimationsExample
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Ensure there are at least two slides to copy animations between
                    if (presentation.Slides.Count < 2)
                    {
                        Console.WriteLine("Presentation must contain at least two slides.");
                        return;
                    }

                    // Source slide (animations will be copied from this slide)
                    ISlide sourceSlide = presentation.Slides[0];

                    // Target slide (animations will be copied to this slide)
                    ISlide targetSlide = presentation.Slides[1];

                    // Get the main animation sequences of both slides
                    ISequence sourceSequence = sourceSlide.Timeline.MainSequence;
                    ISequence targetSequence = targetSlide.Timeline.MainSequence;

                    // Iterate through each effect in the source slide's main sequence
                    for (int i = 0; i < sourceSequence.Count; i++)
                    {
                        IEffect sourceEffect = sourceSequence[i];

                        // Retrieve the shape that the effect is applied to
                        IShape targetShape = sourceEffect.TargetShape;

                        // Add a new effect to the target slide using the same parameters
                        IEffect newEffect = targetSequence.AddEffect(
                            targetShape,
                            sourceEffect.Type,
                            sourceEffect.Subtype,
                            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                        // Copy additional effect properties if needed
                        newEffect.AfterAnimationType = sourceEffect.AfterAnimationType;
                        newEffect.Timing.RepeatUntilEndSlide = sourceEffect.Timing.RepeatUntilEndSlide;
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Comment: format not supported or other exception
            }
        }
    }
}