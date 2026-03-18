using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        try
        {
            var dataDir = "C:\\Presentations\\";
            var inputPath = System.IO.Path.Combine(dataDir, "input.pptx");
            var outputPath = System.IO.Path.Combine(dataDir, "output.pptx");

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                var slide = presentation.Slides[0];
                var shape = slide.Shapes[0] as Aspose.Slides.IAutoShape;
                if (shape != null)
                {
                    slide.Timeline.MainSequence.AddEffect(
                        shape,
                        Aspose.Slides.Animation.EffectType.Fade,
                        Aspose.Slides.Animation.EffectSubtype.None,
                        Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}