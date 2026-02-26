using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideTransitionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an existing presentation or create a new one
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Ensure there is at least one slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Set transition type for the first slide
                slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;

                // Set transition duration (in milliseconds) for the first slide
                slide.SlideShowTransition.Duration = 2000; // 2 seconds

                // Apply the same transition settings to all remaining slides
                for (int i = 1; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide currentSlide = presentation.Slides[i];
                    currentSlide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                    currentSlide.SlideShowTransition.Duration = 2000;
                }

                // Save the presentation
                presentation.Save("SlideTransitions_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}