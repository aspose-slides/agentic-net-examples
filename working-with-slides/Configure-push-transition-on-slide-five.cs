using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideTransitionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Ensure there are at least five slides
            while (presentation.Slides.Count < 5)
            {
                // Add an empty slide using the layout of the first slide
                presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            }

            // Configure Push transition on slide five (index 4)
            presentation.Slides[4].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Push;
            presentation.Slides[4].SlideShowTransition.AdvanceOnClick = true;
            presentation.Slides[4].SlideShowTransition.AdvanceAfterTime = 3000U; // 3 seconds

            // Save the presentation
            string outputPath = "PushTransitionSlide5.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}