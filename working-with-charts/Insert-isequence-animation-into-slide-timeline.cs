using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation with exception handling for unsupported formats
        Aspose.Slides.Presentation presentation;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Format not supported or other loading error
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Get the first slide
        var slide = presentation.Slides[0];

        // Ensure there is at least one shape to animate
        if (slide.Shapes.Count == 0)
        {
            Console.WriteLine("No shapes found on the slide.");
            presentation.Dispose();
            return;
        }

        // Get the first shape
        var shape = slide.Shapes[0];

        // Get the main sequence of the slide's timeline
        var mainSequence = slide.Timeline.MainSequence;

        // Insert an animation effect into the sequence
        // This adds the effect at the end of the sequence
        mainSequence.AddEffect(
            shape,
            EffectType.Appear,
            EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

        // Save the modified presentation
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }

        // Dispose the presentation before exiting
        presentation.Dispose();
    }
}