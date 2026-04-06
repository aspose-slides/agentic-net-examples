using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Set each slide's first effect to repeat until the end of the slide
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISequence sequence = presentation.Slides[i].Timeline.MainSequence;
                    if (sequence.Count > 0)
                    {
                        IEffect effect = sequence[0];
                        effect.Timing.RepeatUntilEndSlide = true;
                    }
                }

                // Ensure subsequent slide effects stop previous sound if present
                for (int i = 1; i < presentation.Slides.Count; i++)
                {
                    IEffect previousEffect = presentation.Slides[i - 1].Timeline.MainSequence[0];
                    IEffect currentEffect = presentation.Slides[i].Timeline.MainSequence[0];
                    if (previousEffect != null && previousEffect.Sound != null)
                    {
                        currentEffect.StopPreviousSound = true;
                    }
                }

                // Generate animation events (optional demonstration)
                using (PresentationAnimationsGenerator generator = new PresentationAnimationsGenerator(presentation))
                {
                    generator.NewAnimation += player =>
                    {
                        Console.WriteLine($"Animation total duration: {player.Duration} ms");
                    };
                    generator.Run(presentation.Slides);
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other processing errors
            Console.WriteLine($"Error processing presentation: {ex.Message}");
        }
    }
}