using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Clone the first slide three times
            Aspose.Slides.ISlide slide1 = presentation.Slides.AddClone(presentation.Slides[0]);
            Aspose.Slides.ISlide slide2 = presentation.Slides.AddClone(presentation.Slides[0]);
            Aspose.Slides.ISlide slide3 = presentation.Slides.AddClone(presentation.Slides[0]);

            // Set AfterAnimationType for effects on the first cloned slide
            Aspose.Slides.Animation.ISequence seq1 = slide1.Timeline.MainSequence;
            foreach (Aspose.Slides.Animation.IEffect effect in seq1)
            {
                effect.AfterAnimationType = Aspose.Slides.Animation.AfterAnimationType.HideOnNextMouseClick;
            }

            // Set AfterAnimationType and color for effects on the second cloned slide
            Aspose.Slides.Animation.ISequence seq2 = slide2.Timeline.MainSequence;
            foreach (Aspose.Slides.Animation.IEffect effect in seq2)
            {
                effect.AfterAnimationType = Aspose.Slides.Animation.AfterAnimationType.Color;
                effect.AfterAnimationColor.Color = Color.Green;
            }

            // Set AfterAnimationType for effects on the third cloned slide
            Aspose.Slides.Animation.ISequence seq3 = slide3.Timeline.MainSequence;
            foreach (Aspose.Slides.Animation.IEffect effect in seq3)
            {
                effect.AfterAnimationType = Aspose.Slides.Animation.AfterAnimationType.HideAfterAnimation;
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}