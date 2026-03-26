using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;
using System.Drawing;

namespace SlidesDemo
{
    class Program
    {
        static void Main()
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            var presentation = new Presentation(inputPath);

            // Clone the first slide three times
            var slide1 = presentation.Slides.AddClone(presentation.Slides[0]);
            var slide2 = presentation.Slides.AddClone(presentation.Slides[0]);
            var slide3 = presentation.Slides.AddClone(presentation.Slides[0]);

            // Set AfterAnimationType for slide 1 effects
            var seq1 = slide1.Timeline.MainSequence;
            foreach (IEffect effect in seq1)
            {
                effect.AfterAnimationType = AfterAnimationType.HideOnNextMouseClick;
            }

            // Set AfterAnimationType and color for slide 2 effects
            var seq2 = slide2.Timeline.MainSequence;
            foreach (IEffect effect in seq2)
            {
                effect.AfterAnimationType = AfterAnimationType.Color;
            }
            // Apply color to the last effect processed
            if (seq2.Count > 0)
            {
                var lastEffect = seq2[seq2.Count - 1];
                lastEffect.AfterAnimationColor.Color = Color.Green;
            }

            // Set AfterAnimationType for slide 3 effects
            var seq3 = slide3.Timeline.MainSequence;
            foreach (IEffect effect in seq3)
            {
                effect.AfterAnimationType = AfterAnimationType.HideAfterAnimation;
            }

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}