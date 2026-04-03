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
            // Input presentation path
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Output presentation path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Load the presentation and process animations
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine($"Failed to load presentation: {ex.Message}");
                // format not supported
                return;
            }

            try
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];
                    ISequence mainSequence = slide.Timeline.MainSequence;

                    // Iterate through all effects in the main sequence
                    foreach (IEffect effect in mainSequence)
                    {
                        IShape targetShape = effect.TargetShape;
                        string shapeName = targetShape != null ? targetShape.Name : "Unnamed Shape";
                        Console.WriteLine($"Slide {slideIndex + 1}: Effect Type = {effect.Type}, Shape = {shapeName}");
                    }
                }

                // Save the presentation before exit
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine($"Presentation saved to: {outputPath}");
            }
            finally
            {
                // Ensure resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}