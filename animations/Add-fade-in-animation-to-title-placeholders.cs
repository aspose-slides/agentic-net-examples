using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;

                    // Check if the shape is a title placeholder
                    if (autoShape != null && autoShape.Placeholder != null && autoShape.Placeholder.Type == Aspose.Slides.PlaceholderType.Title)
                    {
                        // Add a fade‑in animation effect to the title placeholder
                        slide.Timeline.MainSequence.AddEffect(
                            autoShape,
                            Aspose.Slides.Animation.EffectType.Fade,
                            Aspose.Slides.Animation.EffectSubtype.None,
                            Aspose.Slides.Animation.EffectTriggerType.OnClick);
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error processing presentation (possible unsupported format): " + ex.Message);
        }
    }
}