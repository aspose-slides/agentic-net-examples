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
                    // Source slide (first slide)
                    ISlide sourceSlide = presentation.Slides[0];

                    // Target slide (second slide if exists, otherwise create a new empty slide)
                    ISlide targetSlide;
                    if (presentation.Slides.Count > 1)
                    {
                        targetSlide = presentation.Slides[1];
                    }
                    else
                    {
                        ILayoutSlide blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
                        targetSlide = presentation.Slides.AddEmptySlide(blankLayout);
                    }

                    // Get the main animation sequences of both slides
                    ISequence sourceSequence = sourceSlide.Timeline.MainSequence;
                    ISequence targetSequence = targetSlide.Timeline.MainSequence;

                    // Copy each effect from the source slide to the target slide
                    foreach (IEffect sourceEffect in sourceSequence)
                    {
                        // The shape that the effect is applied to
                        IShape targetShape = sourceEffect.TargetShape;
                        if (targetShape == null)
                        {
                            continue; // Skip effects without a target shape
                        }

                        // Add a new effect to the target slide with the same type, subtype and trigger
                        IEffect newEffect = targetSequence.AddEffect(
                            targetShape,
                            sourceEffect.Type,
                            sourceEffect.Subtype,
                            EffectTriggerType.AfterPrevious);

                        // Copy additional properties (timing, after‑animation type, etc.)
                        newEffect.Timing = sourceEffect.Timing;
                        newEffect.AfterAnimationType = sourceEffect.AfterAnimationType;
                        newEffect.AnimateTextType = sourceEffect.AnimateTextType;
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external resources, I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}