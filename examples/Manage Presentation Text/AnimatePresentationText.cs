using System;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get the first effect from the first slide's main animation sequence
        Aspose.Slides.Animation.IEffect effect = presentation.Slides[0].Timeline.MainSequence[0];

        // Set the text animation type to animate by letter
        effect.AnimateTextType = Aspose.Slides.Animation.AnimateTextType.ByLetter;

        // Optionally set a delay between animated text parts (e.g., 20% of the effect duration)
        effect.DelayBetweenTextParts = 20f;

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}