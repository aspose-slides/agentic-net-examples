using System;
using System.IO;
using Aspose.Slides.Export;

namespace CustomizeAnimation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            Aspose.Slides.Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to the slide
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

            // Access the main animation sequence of the slide
            Aspose.Slides.Animation.ISequence mainSequence = slide.Timeline.MainSequence;

            // Add a Fly animation effect to the shape
            mainSequence.AddEffect(
                shape,
                Aspose.Slides.Animation.EffectType.Fly,
                Aspose.Slides.Animation.EffectSubtype.Left,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}