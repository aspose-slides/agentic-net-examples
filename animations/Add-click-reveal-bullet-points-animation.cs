// -----------------------------------------------------------------------------
// Example: Add click reveal bullet points animation using C#
//
// Description:
// Demonstrates how to add click‑triggered fly‑in animations to individual bullet
// points in a PowerPoint slide using Aspose.Slides for .NET. The example creates
// a new presentation, inserts a rectangle shape with a text frame containing
// three bullet paragraphs, and applies a left‑to‑right fly animation that
// starts on mouse click for each bullet. The resulting PPTX file can be used
// to automate presentation creation or to integrate animated content into
// .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Click, Reveal, Bullet, Points,
// Animation, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate the addition of click‑reveal bullet point animations.
// - Build C# tools for generating animated PowerPoint presentations.
// - Integrate slide animation logic into .NET applications.
// - Create or modify PPTX files with custom animation sequences.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "BulletAnimation.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to hold bullet points
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

        // Add a text frame to the shape
        shape.AddTextFrame("Title");
        Aspose.Slides.ITextFrame textFrame = shape.TextFrame;

        // Remove the default empty paragraph
        textFrame.Paragraphs.RemoveAt(0);

        // Create first bullet paragraph
        Aspose.Slides.Paragraph para1 = new Aspose.Slides.Paragraph();
        para1.Text = "First bullet point";
        para1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        para1.ParagraphFormat.Bullet.Char = System.Convert.ToChar(8226); // •
        textFrame.Paragraphs.Add(para1);

        // Create second bullet paragraph
        Aspose.Slides.Paragraph para2 = new Aspose.Slides.Paragraph();
        para2.Text = "Second bullet point";
        para2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        para2.ParagraphFormat.Bullet.Char = System.Convert.ToChar(8226);
        textFrame.Paragraphs.Add(para2);

        // Create third bullet paragraph
        Aspose.Slides.Paragraph para3 = new Aspose.Slides.Paragraph();
        para3.Text = "Third bullet point";
        para3.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        para3.ParagraphFormat.Bullet.Char = System.Convert.ToChar(8226);
        textFrame.Paragraphs.Add(para3);

        // Add click‑triggered animation to each paragraph
        Aspose.Slides.Animation.IEffect effect1 = slide.Timeline.MainSequence.AddEffect(
            para1, Aspose.Slides.Animation.EffectType.Fly,
            Aspose.Slides.Animation.EffectSubtype.Left,
            Aspose.Slides.Animation.EffectTriggerType.OnClick);

        Aspose.Slides.Animation.IEffect effect2 = slide.Timeline.MainSequence.AddEffect(
            para2, Aspose.Slides.Animation.EffectType.Fly,
            Aspose.Slides.Animation.EffectSubtype.Left,
            Aspose.Slides.Animation.EffectTriggerType.OnClick);

        Aspose.Slides.Animation.IEffect effect3 = slide.Timeline.MainSequence.AddEffect(
            para3, Aspose.Slides.Animation.EffectType.Fly,
            Aspose.Slides.Animation.EffectSubtype.Left,
            Aspose.Slides.Animation.EffectTriggerType.OnClick);

        // Save the presentation
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported or other saving error
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}
