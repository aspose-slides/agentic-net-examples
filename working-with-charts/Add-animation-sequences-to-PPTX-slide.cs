using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Get the main animation sequence of the first slide
            Aspose.Slides.Animation.ISequence mainSequence = presentation.Slides[0].Timeline.MainSequence;

            // If there is at least one existing effect, enable rewind on it
            if (mainSequence.Count > 0)
            {
                Aspose.Slides.Animation.IEffect firstEffect = mainSequence[0];
                firstEffect.Timing.Rewind = true;
            }

            // Add a simple appear effect to the first shape on the slide
            if (presentation.Slides[0].Shapes.Count > 0)
            {
                Aspose.Slides.IShape firstShape = presentation.Slides[0].Shapes[0];
                mainSequence.AddEffect(
                    firstShape,
                    Aspose.Slides.Animation.EffectType.Appear,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.OnClick);
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}