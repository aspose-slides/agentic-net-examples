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
            Presentation presentation = new Presentation();

            // Ensure there are at least three slides for demonstration
            while (presentation.Slides.Count < 3)
            {
                presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            }

            // Apply Fade transition with a duration of 2 seconds (2000 ms) to each slide
            foreach (ISlide slide in presentation.Slides)
            {
                slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                slide.SlideShowTransition.Duration = 2000; // duration in milliseconds
            }

            // Define output file path
            string outputPath = "SlideTransitionDemo.pptx";

            try
            {
                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., format not supported)
                // Format not supported
            }
            finally
            {
                // Dispose the presentation
                presentation.Dispose();
            }
        }
    }
}