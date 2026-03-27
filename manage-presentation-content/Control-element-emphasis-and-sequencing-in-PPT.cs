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

        // Add an ellipse shape with some text
        Aspose.Slides.IAutoShape ellipse = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Ellipse, 100, 100, 300, 150);
        ellipse.TextFrame.Text = "Important";

        // Apply an emphasis effect (Fade) to the shape, triggered after the previous effect
        Aspose.Slides.Animation.IEffect effect = slide.Timeline.MainSequence.AddEffect(
            ellipse,
            Aspose.Slides.Animation.EffectType.Fade,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Configure effect properties
        effect.AfterAnimationType = Aspose.Slides.Animation.AfterAnimationType.HideOnNextMouseClick;
        effect.DelayBetweenTextParts = -0.5f; // Negative value specifies delay in seconds
        effect.AnimateTextType = Aspose.Slides.Animation.AnimateTextType.ByLetter;

        // Save the presentation before exiting
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}