// -----------------------------------------------------------------------------
// Example: Create animated title slide with appear effect using C#
//
// Description:
// Demonstrates how to create an animated title slide with an appear effect
// applied to each word using C# and Aspose.Slides for .NET. The example shows
// the required presentation-processing steps for PowerPoint files and
// produces the output as a standalone console application. Developers can use
// this pattern to automate PPTX workflows, validate results, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Animated, Title, Slide, Appear,
// ByWord, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of animated title slides with per‑word appear effects.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace AnimatedTitleSlide
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape for the title
                IAutoShape titleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 100);
                titleShape.AddTextFrame("Welcome to Aspose Slides");

                // Add an appear effect with ByWord animation
                IEffect effect = slide.Timeline.MainSequence.AddEffect(
                    titleShape,
                    EffectType.Appear,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);
                effect.AnimateTextType = AnimateTextType.ByWord;
                effect.DelayBetweenTextParts = -0.5f; // 0.5 seconds between words

                // Save the presentation
                string outPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "AnimatedTitle.pptx");
                presentation.Save(outPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
