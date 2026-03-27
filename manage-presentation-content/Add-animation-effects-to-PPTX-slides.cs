using System;
using System.IO;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            Aspose.Slides.ISlide slide1 = presentation.Slides.AddClone(presentation.Slides[0]);
            Aspose.Slides.ISlide slide2 = presentation.Slides.AddClone(presentation.Slides[0]);
            Aspose.Slides.ISlide slide3 = presentation.Slides.AddClone(presentation.Slides[0]);

            Aspose.Slides.Animation.ISequence seq1 = slide1.Timeline.MainSequence;
            foreach (Aspose.Slides.Animation.IEffect effect in seq1)
            {
                effect.AfterAnimationType = Aspose.Slides.Animation.AfterAnimationType.HideOnNextMouseClick;
            }

            Aspose.Slides.Animation.ISequence seq2 = slide2.Timeline.MainSequence;
            foreach (Aspose.Slides.Animation.IEffect effect in seq2)
            {
                effect.AfterAnimationType = Aspose.Slides.Animation.AfterAnimationType.Color;
                effect.AfterAnimationColor.Color = Color.Green;
            }

            Aspose.Slides.Animation.ISequence seq3 = slide3.Timeline.MainSequence;
            foreach (Aspose.Slides.Animation.IEffect effect in seq3)
            {
                effect.AfterAnimationType = Aspose.Slides.Animation.AfterAnimationType.HideAfterAnimation;
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}