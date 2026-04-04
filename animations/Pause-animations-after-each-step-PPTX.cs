using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace PauseAnimationsExample
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

                // Clone the first slide three times to demonstrate different after‑animation settings
                ISlide slide1 = presentation.Slides.AddClone(presentation.Slides[0]);
                ISlide slide2 = presentation.Slides.AddClone(presentation.Slides[0]);
                ISlide slide3 = presentation.Slides.AddClone(presentation.Slides[0]);

                // Set AfterAnimationType to HideOnNextMouseClick for all effects on slide1
                ISequence seq1 = slide1.Timeline.MainSequence;
                foreach (IEffect effect in seq1)
                {
                    effect.AfterAnimationType = AfterAnimationType.HideOnNextMouseClick;
                }

                // Set AfterAnimationType to Color (Green) for all effects on slide2
                ISequence seq2 = slide2.Timeline.MainSequence;
                foreach (IEffect effect in seq2)
                {
                    effect.AfterAnimationType = AfterAnimationType.Color;
                    effect.AfterAnimationColor.Color = System.Drawing.Color.Green;
                }

                // Set AfterAnimationType to HideAfterAnimation for all effects on slide3
                ISequence seq3 = slide3.Timeline.MainSequence;
                foreach (IEffect effect in seq3)
                {
                    effect.AfterAnimationType = AfterAnimationType.HideAfterAnimation;
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}