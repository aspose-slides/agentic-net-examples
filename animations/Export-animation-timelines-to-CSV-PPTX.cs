using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace AnimationTimelineExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output CSV file path
            string outputCsvPath = "animation_timeline.csv";
            // Output presentation path (required to save before exit)
            string outputPresPath = "output.pptx";

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
                    // Create animations generator
                    using (PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation))
                    {
                        // Prepare CSV writer
                        using (StreamWriter writer = new StreamWriter(outputCsvPath))
                        {
                            // Write CSV header
                            writer.WriteLine("SlideIndex,EffectIndex,EffectType");

                            // Run animation generation (required to populate timelines)
                            animationsGenerator.Run(presentation.Slides);
                            
                            // Iterate through slides and extract main sequence effects
                            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                            {
                                ISlide slide = presentation.Slides[slideIndex];
                                ISequence mainSequence = slide.Timeline.MainSequence;
                                for (int effectIndex = 0; effectIndex < mainSequence.Count; effectIndex++)
                                {
                                    IEffect effect = mainSequence[effectIndex];
                                    string effectType = effect.GetType().Name;
                                    writer.WriteLine($"{slideIndex},{effectIndex},{effectType}");
                                }
                            }
                        }

                        // Save presentation before exiting (as required)
                        presentation.Save(outputPresPath, SaveFormat.Pptx);
                    }
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}