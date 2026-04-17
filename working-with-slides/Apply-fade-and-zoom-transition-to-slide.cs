using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

class Program
{
    static void Main()
    {
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "CustomTransition.pptx");
        try
        {
            Presentation pres = new Presentation();
            // Ensure there are at least two slides
            ISlide slide1 = pres.Slides[0];
            ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
            // Apply Fade transition to the first slide
            slide1.SlideShowTransition.Type = TransitionType.Fade;
            // Add a Zoom frame on the first slide linking to the second slide
            IZoomFrame zoomFrame = slide1.Shapes.AddZoomFrame(150, 20, 100, 100, slide2);
            zoomFrame.TransitionDuration = 2.0f;
            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions
        }
    }
}