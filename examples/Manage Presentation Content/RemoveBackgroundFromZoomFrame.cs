using System;

namespace RemoveZoomBackground
{
    class Program
    {
        static void Main(string[] args)
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Ensure there are enough slides for the zoom targets
            Aspose.Slides.ISlide firstSlide = pres.Slides[0];
            Aspose.Slides.ILayoutSlide layout = firstSlide.LayoutSlide;
            Aspose.Slides.ISlide targetSlide1 = pres.Slides.AddEmptySlide(layout);
            Aspose.Slides.ISlide targetSlide2 = pres.Slides.AddEmptySlide(layout);

            // Add a first zoom frame (optional)
            Aspose.Slides.IZoomFrame zoomFrame1 = firstSlide.Shapes.AddZoomFrame(50, 20, 100, 100, targetSlide1);

            // Add the second zoom frame (topic) and remove its background
            Aspose.Slides.IZoomFrame zoomFrame2 = firstSlide.Shapes.AddZoomFrame(200, 20, 100, 100, targetSlide2);
            zoomFrame2.ShowBackground = false;

            // Save the presentation
            pres.Save("RemoveZoomBackground.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}