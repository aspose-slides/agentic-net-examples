using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape to hold bullet points
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300) as Aspose.Slides.IAutoShape;

        // Ensure the shape has a text frame
        if (autoShape != null && autoShape.TextFrame == null)
        {
            autoShape.AddTextFrame("");
        }

        // Define bullet texts
        string[] bulletTexts = new string[] { "First bullet", "Second bullet", "Third bullet" };

        // Add bullet paragraphs to the text frame
        for (int i = 0; i < bulletTexts.Length; i++)
        {
            Aspose.Slides.IParagraph paragraph = new Aspose.Slides.Paragraph();
            paragraph.Text = bulletTexts[i];
            paragraph.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            paragraph.ParagraphFormat.Bullet.Char = '·';
            autoShape.TextFrame.Paragraphs.Add(paragraph);
        }

        // Add click‑triggered appear animation for each paragraph
        Aspose.Slides.Animation.ISequence mainSequence = slide.Timeline.MainSequence;
        for (int i = 0; i < autoShape.TextFrame.Paragraphs.Count; i++)
        {
            Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[i];
            Aspose.Slides.Animation.IEffect effect = mainSequence.AddEffect(paragraph, Aspose.Slides.Animation.EffectType.Appear, Aspose.Slides.Animation.EffectSubtype.None, Aspose.Slides.Animation.EffectTriggerType.OnClick);
            effect.Timing.TriggerDelayTime = 0f;
        }

        // Save the presentation
        string outPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "BulletReveal_out.pptx");
        try
        {
            presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}