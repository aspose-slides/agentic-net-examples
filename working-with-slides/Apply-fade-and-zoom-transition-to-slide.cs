using System;
using System.IO;
using Aspose.Slides.Export;

namespace CustomTransitionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "CustomTransition.pptx");

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a second slide to serve as the zoom target
                Aspose.Slides.ISlide targetSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

                // Add a ZoomFrame on the first slide linking to the second slide
                Aspose.Slides.IZoomFrame zoomFrame = presentation.Slides[0].Shapes.AddZoomFrame(150, 20, 50, 50, targetSlide);
                // Set the transition duration for the zoom effect
                zoomFrame.TransitionDuration = 2.0f;

                // Apply a Fade transition to the first slide
                presentation.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}