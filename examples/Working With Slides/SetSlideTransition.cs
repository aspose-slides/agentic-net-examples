using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation (adds a default slide)
        Presentation presentation = new Presentation();

        // Set the transition type for the first slide to Circle
        presentation.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Circle;

        // Optionally set the transition duration to 2 seconds (2000 milliseconds)
        presentation.Slides[0].SlideShowTransition.Duration = 2000;

        // Save the presentation to disk
        presentation.Save("SlideTransition_out.pptx", SaveFormat.Pptx);
    }
}