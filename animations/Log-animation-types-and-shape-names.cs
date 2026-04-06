using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace AnimationLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Iterate through all slides
                foreach (ISlide slide in presentation.Slides)
                {
                    // Get the main animation sequence of the slide
                    ISequence mainSequence = slide.Timeline.MainSequence;

                    // Iterate through each effect in the main sequence
                    foreach (IEffect effect in mainSequence)
                    {
                        // Retrieve the effect type
                        EffectType effectType = effect.Type;

                        // Retrieve the target shape (if any) and its name
                        IShape targetShape = effect.TargetShape;
                        string shapeName = targetShape != null ? targetShape.Name : "None";

                        // Log the effect type and associated shape name
                        Console.WriteLine($"Slide {slide.SlideNumber}: Effect Type = {effectType}, Shape = {shapeName}");
                    }
                }

                // Save the presentation before exiting
                string outputPath = "output.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}