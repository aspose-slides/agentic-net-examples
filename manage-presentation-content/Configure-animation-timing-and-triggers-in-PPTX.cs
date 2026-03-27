using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace AnimationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists, otherwise create a new one
            Aspose.Slides.Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }

            // Ensure there is at least one slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to the slide
            Aspose.Slides.IShape rectShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 100, 100);

            // Add a Fade effect to the rectangle
            Aspose.Slides.Animation.IEffect fadeEffect = slide.Timeline.MainSequence.AddEffect(
                rectShape,
                Aspose.Slides.Animation.EffectType.Fade,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Configure timing: enable rewind and repeat until end of slide
            fadeEffect.Timing.Rewind = true;
            fadeEffect.Timing.RepeatUntilEndSlide = true;

            // Add a second rectangle shape for a FadedZoom effect
            Aspose.Slides.IShape zoomShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 200, 50, 100, 100);

            // Add a FadedZoom effect with ObjectCenter subtype
            Aspose.Slides.Animation.IEffect zoomEffect = slide.Timeline.MainSequence.AddEffect(
                zoomShape,
                Aspose.Slides.Animation.EffectType.FadedZoom,
                Aspose.Slides.Animation.EffectSubtype.ObjectCenter,
                Aspose.Slides.Animation.EffectTriggerType.OnClick);

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}