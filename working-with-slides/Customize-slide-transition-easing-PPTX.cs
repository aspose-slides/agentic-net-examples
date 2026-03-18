using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();

            // Ensure there are at least three slides
            var layout = presentation.Slides[0].LayoutSlide;
            var slide2 = presentation.Slides.AddEmptySlide(layout);
            var slide3 = presentation.Slides.AddEmptySlide(layout);

            // Slide 1: Circle transition, 3 seconds, advance on click
            var slide1Transition = presentation.Slides[0].SlideShowTransition;
            slide1Transition.Type = Aspose.Slides.SlideShow.TransitionType.Circle;
            slide1Transition.Duration = 3000;
            slide1Transition.AdvanceOnClick = true;

            // Slide 2: Comb transition, 5 seconds, advance after time
            var slide2Transition = presentation.Slides[1].SlideShowTransition;
            slide2Transition.Type = Aspose.Slides.SlideShow.TransitionType.Comb;
            slide2Transition.Duration = 5000;
            slide2Transition.AdvanceOnClick = false;
            slide2Transition.AdvanceAfter = true;
            slide2Transition.AdvanceAfterTime = 5000;

            // Slide 3: Zoom transition, 7 seconds, advance on click
            var slide3Transition = presentation.Slides[2].SlideShowTransition;
            slide3Transition.Type = Aspose.Slides.SlideShow.TransitionType.Zoom;
            slide3Transition.Duration = 7000;
            slide3Transition.AdvanceOnClick = true;

            // Save the presentation
            presentation.Save("SlideTransitions_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}