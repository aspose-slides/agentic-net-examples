using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace AnimationCompatibilityChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.ppt");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Define a set of effect types considered supported by older PowerPoint versions
                    EffectType[] supportedEffects = new EffectType[]
                    {
                        EffectType.Appear,
                        EffectType.Fade,
                        EffectType.Fly,
                        EffectType.Wipe,
                        EffectType.Zoom,
                        EffectType.PathArcDown,
                        EffectType.PathArcUp,
                        EffectType.PathArcLeft,
                        EffectType.PathArcRight
                    };

                    // Iterate through slides and their main sequence effects
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];
                        ISequence mainSequence = slide.Timeline.MainSequence;

                        for (int effectIndex = 0; effectIndex < mainSequence.Count; effectIndex++)
                        {
                            IEffect effect = mainSequence[effectIndex];
                            EffectType effectType = effect.Type;

                            bool isSupported = false;
                            foreach (EffectType supported in supportedEffects)
                            {
                                if (effectType == supported)
                                {
                                    isSupported = true;
                                    break;
                                }
                            }

                            if (!isSupported)
                            {
                                Console.WriteLine($"Slide {slideIndex + 1}, Effect {effectIndex + 1}: Unsupported animation effect \"{effectType}\" for older PowerPoint versions.");
                            }
                        }
                    }

                    // Attempt to save as older PPT format
                    try
                    {
                        presentation.Save(outputPath, SaveFormat.Ppt);
                        Console.WriteLine("Presentation saved successfully to: " + outputPath);
                    }
                    catch (Exception saveEx)
                    {
                        // Format not supported or other saving issue
                        Console.WriteLine("Failed to save presentation in older format. Format may not be supported.");
                        // Comment: format not supported
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions related to loading or processing
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}