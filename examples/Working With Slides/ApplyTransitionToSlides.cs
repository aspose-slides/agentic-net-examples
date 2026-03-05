using System;
using Aspose.Slides;
using Aspose.Slides.SlideShow;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Presentation presentation = new Presentation("input.pptx");

        // Apply a Fade transition with a 2‑second duration to each slide
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            // Set the transition type
            presentation.Slides[i].SlideShowTransition.Type = TransitionType.Fade;
            // Set the transition duration (milliseconds)
            presentation.Slides[i].SlideShowTransition.Duration = 2000;
            // Ensure the slide advances on mouse click
            presentation.Slides[i].SlideShowTransition.AdvanceOnClick = true;
        }

        // Save the modified presentation
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}