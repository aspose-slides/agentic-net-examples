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
            var presentation = new Aspose.Slides.Presentation();

            // Ensure there are at least three slides
            while (presentation.Slides.Count < 3)
            {
                presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            }

            // Set transition for slide 1
            presentation.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
            presentation.Slides[0].SlideShowTransition.AdvanceOnClick = true;
            presentation.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000; // 3 seconds

            // Set transition for slide 2
            presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Wipe;
            presentation.Slides[1].SlideShowTransition.AdvanceOnClick = false;
            presentation.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000; // 5 seconds

            // Set transition for slide 3
            presentation.Slides[2].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Zoom;
            presentation.Slides[2].SlideShowTransition.AdvanceOnClick = true;
            presentation.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000; // 7 seconds

            // Configure slide show settings
            presentation.SlideShowSettings.Loop = true;
            presentation.SlideShowSettings.UseTimings = true;
            presentation.SlideShowSettings.SlideShowType = new Aspose.Slides.PresentedBySpeaker();

            // Save the presentation
            presentation.Save("SlideShowOptions.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}