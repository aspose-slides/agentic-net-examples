using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Set the slide show type to PresentedBySpeaker (full screen)
        pres.SlideShowSettings.SlideShowType = new Aspose.Slides.PresentedBySpeaker();

        // Enable media controls in the slide show
        pres.SlideShowSettings.ShowMediaControls = true;

        // Define a slide range (e.g., slides 1 to 3) for the slide show
        Aspose.Slides.SlidesRange range = new Aspose.Slides.SlidesRange { Start = 1, End = 3 };
        pres.SlideShowSettings.Slides = range;

        // Save the presentation in PPTX format
        pres.Save("AdjustedSlideShowSettings.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}