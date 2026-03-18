using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideTransitionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Define transition type and duration
                Aspose.Slides.SlideShow.TransitionType transitionType = Aspose.Slides.SlideShow.TransitionType.Fade;
                int transitionDuration = 2000; // milliseconds

                // Apply transition settings to each slide
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];
                    slide.SlideShowTransition.Type = transitionType;
                    slide.SlideShowTransition.Duration = transitionDuration;
                }

                // Save the presentation
                presentation.Save("SlideTransitions.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}