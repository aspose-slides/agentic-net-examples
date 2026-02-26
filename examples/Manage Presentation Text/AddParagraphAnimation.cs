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

        // Add a rectangle AutoShape with two paragraphs of text
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            ShapeType.Rectangle, 50, 100, 400, 100);
        autoShape.AddTextFrame("First paragraph.\nSecond paragraph.");

        // Retrieve the first paragraph from the shape's text frame
        Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

        // Add a Fly animation effect to the selected paragraph
        Aspose.Slides.Animation.IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(
            paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

        // Set the animate text type to animate by letter
        effect.AnimateTextType = AnimateTextType.ByLetter;

        // Save the presentation to a file
        presentation.Save("ParagraphAnimation_out.pptx", SaveFormat.Pptx);
    }
}