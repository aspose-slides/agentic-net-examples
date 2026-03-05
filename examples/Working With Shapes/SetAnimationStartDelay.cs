using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get the first effect from the first slide's main animation sequence
        Aspose.Slides.Animation.IEffect effect = presentation.Slides[0].Timeline.MainSequence[0];

        // Set the start delay (trigger delay) to 2 seconds
        effect.Timing.TriggerDelayTime = 2.0f;

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}