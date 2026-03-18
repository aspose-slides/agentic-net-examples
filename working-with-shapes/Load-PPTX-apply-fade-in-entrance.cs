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
            string dataDir = "C:\\Presentations\\";
            string inputPath = System.IO.Path.Combine(dataDir, "input.pptx");
            string outputPath = System.IO.Path.Combine(dataDir, "output.pptx");

            Presentation presentation = new Presentation(inputPath);
            ISlide slide = presentation.Slides[0];
            IShape shape = slide.Shapes[0]; // target shape

            // Apply fade-in entrance animation
            slide.Timeline.MainSequence.AddEffect(
                shape,
                Aspose.Slides.Animation.EffectType.Fade,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}