using System;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load the existing PPTX file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Apply a Fade transition to the first slide
            presentation.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
            // Set the transition duration to 2 seconds (2000 milliseconds)
            presentation.Slides[0].SlideShowTransition.Duration = 2000;

            // Save the presentation with the applied transition
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
    }
}