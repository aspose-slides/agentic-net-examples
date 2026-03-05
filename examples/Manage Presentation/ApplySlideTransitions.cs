using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Add two additional empty slides using the layout of the first slide
        var layout = presentation.Slides[0].LayoutSlide;
        var slide2 = presentation.Slides.AddEmptySlide(layout);
        var slide3 = presentation.Slides.AddEmptySlide(layout);

        // Apply a Circle transition to the first slide
        presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
        presentation.Slides[0].SlideShowTransition.AdvanceOnClick = true;
        presentation.Slides[0].SlideShowTransition.AdvanceAfter = true;
        presentation.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000; // 3 seconds
        presentation.Slides[0].SlideShowTransition.Duration = 500; // transition duration in ms

        // Apply a Comb transition to the second slide
        presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;
        presentation.Slides[1].SlideShowTransition.AdvanceOnClick = true;
        presentation.Slides[1].SlideShowTransition.AdvanceAfter = true;
        presentation.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000; // 5 seconds
        presentation.Slides[1].SlideShowTransition.Duration = 700;

        // Apply a Zoom transition to the third slide
        presentation.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;
        presentation.Slides[2].SlideShowTransition.AdvanceOnClick = true;
        presentation.Slides[2].SlideShowTransition.AdvanceAfter = true;
        presentation.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000; // 7 seconds
        presentation.Slides[2].SlideShowTransition.Duration = 900;

        // Save the presentation to a PPTX file
        presentation.Save("SlideTransitions_out.pptx", SaveFormat.Pptx);
    }
}