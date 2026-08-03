// -----------------------------------------------------------------------------
// Example: Apply fade out animation to final bullet using C#
//
// Description:
// Demonstrates how to apply a fade-out animation effect to the final bullet
// point on agenda slides using Aspose.Slides for .NET. The example loads a
// presentation, identifies slides with a title containing "Agenda", finds the
// last bullet shape, adds a fade-out effect to its final paragraph, and saves
// the modified file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Fade Out, Animation, Final Bullet,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automatically add fade-out animation to the last bullet of agenda slides.
// - Build C# utilities for PowerPoint presentation enhancement.
// - Integrate animation logic into .NET applications that generate or modify PPTX files.
// - Ensure consistent slide animations before publishing presentations.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                foreach (ISlide slide in presentation.Slides)
                {
                    // Identify agenda slides by title containing "Agenda"
                    if (slide.Shapes.Count > 0 && slide.Shapes[0] is IAutoShape titleShape)
                    {
                        string titleText = titleShape.TextFrame.Text;
                        if (!string.IsNullOrEmpty(titleText) && titleText.IndexOf("Agenda", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            // Find the last shape that contains paragraphs (assumed bullet points)
                            IAutoShape lastBulletShape = null;
                            foreach (IShape shape in slide.Shapes)
                            {
                                if (shape is IAutoShape autoShape && autoShape.TextFrame != null && autoShape.TextFrame.Paragraphs.Count > 0)
                                {
                                    lastBulletShape = autoShape;
                                }
                            }

                            if (lastBulletShape != null)
                            {
                                // Get the final paragraph (last bullet point)
                                IParagraph lastParagraph = lastBulletShape.TextFrame.Paragraphs[lastBulletShape.TextFrame.Paragraphs.Count - 1];

                                // Add a fade-out animation effect to the final bullet point
                                IEffect fadeEffect = slide.Timeline.MainSequence.AddEffect(
                                    lastParagraph,
                                    EffectType.Fade,
                                    EffectSubtype.None,
                                    EffectTriggerType.AfterPrevious);

                                // Set duration of the fade-out effect (in seconds)
                                fadeEffect.Timing.Duration = 1.0f;
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
