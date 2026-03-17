using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (FileStream fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Presentation presentation = new Presentation(fileStream))
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a rectangle shape with some text
                    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
                    shape.TextFrame.Text = "Hello Aspose";

                    // Add a Fly animation effect to the shape
                    slide.Timeline.MainSequence.AddEffect(
                        shape,
                        Aspose.Slides.Animation.EffectType.Fly,
                        Aspose.Slides.Animation.EffectSubtype.None,
                        Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                    // Save the presentation with ZIP64 mode always enabled
                    PptxOptions saveOptions = new PptxOptions();
                    saveOptions.Zip64Mode = Zip64Mode.Always;
                    presentation.Save(outputPath, SaveFormat.Pptx, saveOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}