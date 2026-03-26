using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

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

        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        Aspose.Slides.ISlide slide = presentation.Slides[0];
        Aspose.Slides.Animation.ISequence mainSeq = slide.Timeline.MainSequence;

        if (mainSeq.Count > 0)
        {
            Aspose.Slides.Animation.IEffect effect = mainSeq[0];
            effect.Timing.RepeatUntilEndSlide = true;
            effect.Timing.RepeatUntilNextClick = true;
        }

        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}