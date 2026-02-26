using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentationAdvanceSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Ensure there are three slides
            presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Slide 0: Circle transition, advance on click, after 3 seconds
            presentation.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Circle;
            presentation.Slides[0].SlideShowTransition.AdvanceOnClick = true;
            presentation.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000u;

            // Slide 1: Comb transition, advance on click, after 5 seconds
            presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Comb;
            presentation.Slides[1].SlideShowTransition.AdvanceOnClick = true;
            presentation.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000u;

            // Slide 2: Zoom transition, advance on click, after 7 seconds
            presentation.Slides[2].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Zoom;
            presentation.Slides[2].SlideShowTransition.AdvanceOnClick = true;
            presentation.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000u;

            // Save the presentation
            presentation.Save("AdvancedSlides.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}