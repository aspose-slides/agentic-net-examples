using System;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Apply a Fade transition with a 2‑second duration to each slide
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            presentation.Slides[i].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
            presentation.Slides[i].SlideShowTransition.Duration = 2000; // duration in milliseconds
        }

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}