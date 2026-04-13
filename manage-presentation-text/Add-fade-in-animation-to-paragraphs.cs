using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "intro.pptx";
        string outputPath = "intro_animated.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                if (autoShape == null || autoShape.TextFrame == null)
                    continue;

                for (int i = 0; i < autoShape.TextFrame.Paragraphs.Count; i++)
                {
                    Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[i];
                    Aspose.Slides.Animation.IEffect effect = slide.Timeline.MainSequence.AddEffect(
                        paragraph,
                        Aspose.Slides.Animation.EffectType.Fade,
                        Aspose.Slides.Animation.EffectSubtype.None,
                        Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
                    effect.AnimateTextType = Aspose.Slides.Animation.AnimateTextType.AllAtOnce;
                }
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}