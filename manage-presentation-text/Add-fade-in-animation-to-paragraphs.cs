// -----------------------------------------------------------------------------
// Example: Add fade in animation to paragraphs using C#
//
// Description:
// Demonstrates how to add a fade‑in animation effect to each paragraph in
// text‑containing shapes of the first slide using Aspose.Slides for .NET.
// The example loads an existing PPTX, iterates through AutoShapes, applies a
// Fade effect to every paragraph, and saves the animated presentation.
// This pattern can be used to automate paragraph‑level animations in PowerPoint
// files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Fade, Animation, Paragraphs,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically add fade‑in animation to paragraphs in a PPTX.
// - Build .NET tools that enhance slide content with animation effects.
// - Generate or modify presentations with automated text animations.
// - Validate animation workflows before publishing.
// -----------------------------------------------------------------------------
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
