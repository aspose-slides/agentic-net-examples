using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Presentation presentation = new Presentation("input.pptx");

        // Iterate through all slides
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            ISlide slide = presentation.Slides[slideIndex];

            // Get the main animation sequence of the slide
            ISequence mainSequence = slide.Timeline.MainSequence;

            // Iterate through all shapes on the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                IShape shape = slide.Shapes[shapeIndex];

                // Check if the shape contains a text frame
                ITextFrame textFrame = shape as ITextFrame;
                if (textFrame == null)
                    continue;

                // Iterate through all paragraphs in the text frame
                for (int paraIndex = 0; paraIndex < textFrame.Paragraphs.Count; paraIndex++)
                {
                    IParagraph paragraph = textFrame.Paragraphs[paraIndex];

                    // Retrieve animation effects applied to this paragraph
                    IEffect[] effects = mainSequence.GetEffectsByParagraph(paragraph);

                    Console.WriteLine($"Slide {slideIndex + 1}, Shape {shapeIndex + 1}, Paragraph {paraIndex + 1} has {effects.Length} effect(s).");

                    // Output details of each effect
                    for (int effIndex = 0; effIndex < effects.Length; effIndex++)
                    {
                        IEffect effect = effects[effIndex];
                        Console.WriteLine($"  Effect {effIndex + 1}: Type = {effect.Type}, Subtype = {effect.Subtype}");
                    }
                }
            }
        }

        // Save the presentation after processing
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}