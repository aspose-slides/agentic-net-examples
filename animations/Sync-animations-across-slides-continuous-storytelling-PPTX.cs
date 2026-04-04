using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace AnimationSyncExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            var inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Ensure input file exists; if not, create a basic presentation
            if (!File.Exists(inputPath))
            {
                var pres = new Presentation();
                // Add an empty slide based on the default layout
                pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
                // Save the newly created presentation for later use
                pres.Save(inputPath, SaveFormat.Pptx);
                pres.Dispose();
            }

            try
            {
                // Load the presentation
                var presentation = new Presentation(inputPath);

                // Iterate through each slide to synchronize animations
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    var slide = presentation.Slides[i];
                    var mainSequence = slide.Timeline.MainSequence;

                    // Set each effect to repeat until the end of its slide
                    for (int j = 0; j < mainSequence.Count; j++)
                    {
                        var effect = mainSequence[j];
                        effect.Timing.RepeatUntilEndSlide = true;

                        // If there is a previous slide with sound, stop it on the current effect
                        if (i > 0)
                        {
                            var previousEffect = presentation.Slides[i - 1].Timeline.MainSequence[0];
                            if (previousEffect.Sound != null)
                            {
                                effect.StopPreviousSound = true;
                            }
                        }
                    }
                }

                // Generate animation events (optional, demonstrates usage of PresentationAnimationsGenerator)
                using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
                {
                    animationsGenerator.NewAnimation += player =>
                    {
                        Console.WriteLine($"Animation total duration: {player.Duration}");
                    };
                    animationsGenerator.Run(presentation.Slides);
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine($"Error processing presentation: {ex.Message}");
            }
        }
    }
}