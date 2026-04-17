using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add two more slides by cloning the first slide
            presentation.Slides.AddClone(presentation.Slides[0]);
            presentation.Slides.AddClone(presentation.Slides[0]);

            // Set transition for slide 1
            presentation.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Circle;
            presentation.Slides[0].SlideShowTransition.AdvanceOnClick = true;
            presentation.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000; // 3 seconds

            // Set transition for slide 2
            presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Comb;
            presentation.Slides[1].SlideShowTransition.AdvanceOnClick = true;
            presentation.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000; // 5 seconds

            // Set transition for slide 3
            presentation.Slides[2].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Zoom;
            presentation.Slides[2].SlideShowTransition.AdvanceOnClick = true;
            presentation.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000; // 7 seconds

            // Save the presentation
            presentation.Save("SlideTransitions.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, I/O errors)
            // Format not supported: comment if needed
        }
    }
}