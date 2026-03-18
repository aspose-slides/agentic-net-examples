using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Get the first shape as an AutoShape
            Aspose.Slides.IAutoShape autoShape = slide.Shapes[0] as Aspose.Slides.IAutoShape;

            // If the shape is not an AutoShape or has no TextFrame, create one
            if (autoShape == null)
            {
                autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                autoShape.AddTextFrame("Paragraph 1\nParagraph 2");
            }
            else if (autoShape.TextFrame == null)
            {
                autoShape.AddTextFrame("Paragraph 1\nParagraph 2");
            }

            // Apply animation effect to each paragraph
            for (int i = 0; i < autoShape.TextFrame.Paragraphs.Count; i++)
            {
                Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[i];
                Aspose.Slides.Animation.IEffect effect = slide.Timeline.MainSequence.AddEffect(
                    paragraph,
                    Aspose.Slides.Animation.EffectType.Fly,
                    Aspose.Slides.Animation.EffectSubtype.Left,
                    Aspose.Slides.Animation.EffectTriggerType.OnClick);
                // Optional: set a delay for each paragraph
                effect.Timing.TriggerDelayTime = i * 0.5f;
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}