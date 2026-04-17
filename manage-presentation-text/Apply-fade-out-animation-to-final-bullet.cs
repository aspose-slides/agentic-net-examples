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