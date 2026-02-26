using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a few empty slides (the first slide already exists)
        presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

        // Define the slide range to be shown in the slide show (slides 2 to 4)
        Aspose.Slides.SlidesRange slideRange = new Aspose.Slides.SlidesRange();
        slideRange.Start = 2; // 1‑based index
        slideRange.End = 4;

        // Apply the slide range to the slide show settings
        presentation.SlideShowSettings.Slides = slideRange;

        // Save the presentation before exiting
        presentation.Save("SelectSlides_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}