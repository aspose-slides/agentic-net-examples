using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "PushTransition.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Ensure the presentation has at least five slides
        while (presentation.Slides.Count < 5)
        {
            presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        }

        // Configure Push transition on slide five (index 4)
        presentation.Slides[4].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Push;
        presentation.Slides[4].SlideShowTransition.AdvanceOnClick = true;
        presentation.Slides[4].SlideShowTransition.AdvanceAfterTime = 3000; // 3 seconds

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}