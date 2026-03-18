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

            // Configure transition for the first slide
            Aspose.Slides.ISlideShowTransition transition1 = presentation.Slides[0].SlideShowTransition;
            transition1.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
            transition1.AdvanceAfter = true;
            transition1.AdvanceAfterTime = 3000; // 3 seconds

            // Add a second slide and configure its transition
            Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            Aspose.Slides.ISlideShowTransition transition2 = slide2.SlideShowTransition;
            transition2.Type = Aspose.Slides.SlideShow.TransitionType.Wipe;
            transition2.AdvanceAfter = true;
            transition2.AdvanceAfterTime = 5000; // 5 seconds

            // Save the presentation
            presentation.Save("AutoAdvanceSlides.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}