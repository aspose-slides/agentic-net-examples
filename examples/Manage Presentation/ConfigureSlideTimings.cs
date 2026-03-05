using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Enable use of timings in slide show settings
        presentation.SlideShowSettings.UseTimings = true;

        // Configure the first slide to auto-advance after 3 seconds
        Aspose.Slides.ISlideShowTransition transition1 = presentation.Slides[0].SlideShowTransition;
        transition1.AdvanceAfter = true;
        transition1.AdvanceAfterTime = 3000; // time in milliseconds

        // Add a second slide for demonstration
        Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        Aspose.Slides.ISlideShowTransition transition2 = secondSlide.SlideShowTransition;
        transition2.AdvanceAfter = true;
        transition2.AdvanceAfterTime = 5000; // time in milliseconds

        // Save the presentation
        presentation.Save("SlideTimings_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}