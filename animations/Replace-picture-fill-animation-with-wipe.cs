using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace ReplacePictureFillAnimations
{
    class Program
    {
        static void Main(string[] args)
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
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];
                        ISequence sequence = slide.Timeline.MainSequence;

                        // Iterate through all effects in the main sequence
                        for (int effectIndex = 0; effectIndex < sequence.Count; effectIndex++)
                        {
                            IEffect effect = sequence[effectIndex];

                            // Check if the effect targets a picture frame (picture fill animation)
                            if (effect.TargetShape is IPictureFrame)
                            {
                                // Replace the effect type with a wipe effect while preserving timing
                                effect.Type = EffectType.Wipe;
                                // Timing properties (Delay, Duration, etc.) remain unchanged
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported file format here
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}