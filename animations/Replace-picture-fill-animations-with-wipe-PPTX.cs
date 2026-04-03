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
            // Expect input and output file paths as arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ReplacePictureFillAnimations <input.pptx> <output.pptx>");
                return;
            }

            var inputPath = args[0];
            var outputPath = args[1];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file does not exist: {inputPath}");
                return;
            }

            try
            {
                // Load presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through each slide
                    foreach (ISlide slide in pres.Slides)
                    {
                        // Get the main animation sequence of the slide
                        ISequence sequence = slide.Timeline.MainSequence;

                        // Iterate over each effect in the sequence
                        for (int i = 0; i < sequence.Count; i++)
                        {
                            IEffect effect = sequence[i];

                            // Check if the target shape is a picture frame (picture fill animation)
                            if (effect.TargetShape is IPictureFrame)
                            {
                                // Replace the effect type with Wipe while preserving timing
                                effect.Type = EffectType.Wipe;
                                // Timing properties (e.g., Delay, Duration) remain unchanged
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
                // Comment: format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}