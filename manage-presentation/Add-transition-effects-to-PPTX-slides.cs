using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide (already present)
            Aspose.Slides.ISlide slide1 = presentation.Slides[0];

            // Add two more empty slides based on the layout of the first slide
            Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            Aspose.Slides.ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Apply transition effects
            slide1.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
            slide1.SlideShowTransition.AdvanceOnClick = true;
            slide1.SlideShowTransition.AdvanceAfterTime = 3000;

            slide2.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Wipe;
            slide2.SlideShowTransition.AdvanceOnClick = true;
            slide2.SlideShowTransition.AdvanceAfterTime = 5000;

            slide3.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Zoom;
            slide3.SlideShowTransition.AdvanceOnClick = true;
            slide3.SlideShowTransition.AdvanceAfterTime = 7000;

            // Save the presentation
            presentation.Save("TransitionDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}