using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        // Load existing presentation if it exists, otherwise create a new one
        var presentation = File.Exists(inputPath) ? new Aspose.Slides.Presentation(inputPath) : new Aspose.Slides.Presentation();

        // If a new presentation was created, add a shape to animate
        if (!File.Exists(inputPath))
        {
            var slide = presentation.Slides[0];
            var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);
            shape.TextFrame.Text = "Hello";
        }

        // Access the first slide and its main animation sequence
        var slide0 = presentation.Slides[0];
        var mainSequence = slide0.Timeline.MainSequence;

        // Add a fade effect to the first shape on the slide
        var targetShape = slide0.Shapes[0];
        var effect = mainSequence.AddEffect(
            targetShape,
            Aspose.Slides.Animation.EffectType.Fade,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Configure the effect to repeat until the end of the slide
        effect.Timing.RepeatUntilEndSlide = true;

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}