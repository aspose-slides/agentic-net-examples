using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace InsertAnimationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Get the first shape on the slide (ensure it exists)
                if (slide.Shapes.Count == 0)
                {
                    Console.WriteLine("No shapes found on the slide.");
                    presentation.Dispose();
                    return;
                }

                IShape shape = slide.Shapes[0];

                // Insert an animation effect into the slide's main sequence
                ISequence mainSequence = slide.Timeline.MainSequence;
                IEffect effect = mainSequence.AddEffect(
                    shape,
                    EffectType.Appear,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Optionally set additional effect properties (e.g., repeat until end of slide)
                effect.Timing.RepeatUntilEndSlide = true;

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported file format scenario
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., external URL or web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}