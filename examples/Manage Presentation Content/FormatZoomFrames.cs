using System;
using System.Drawing;
using Aspose.Slides;

namespace ZoomFrameExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide (created by default)
            Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

            // Add a second slide to serve as the target of the zoom frame
            Aspose.Slides.ISlide targetSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Add a Zoom frame to the first slide that links to the second slide
            Aspose.Slides.IZoomFrame zoomFrame = firstSlide.Shapes.AddZoomFrame(150f, 20f, 100f, 100f, targetSlide);

            // Optionally modify properties of the zoom frame
            zoomFrame.ShowBackground = false; // Hide background of the target slide in the zoom preview

            // Save the presentation
            presentation.Save("ZoomFrames_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}