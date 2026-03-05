using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Add two additional empty slides based on the layout of the first slide
            Aspose.Slides.ISlide slide1 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
            Aspose.Slides.ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

            // Add the first zoom frame on the first slide linking to slide1
            Aspose.Slides.IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(50, 50, 100, 100, slide1);

            // Add the second zoom frame on the first slide linking to slide2
            Aspose.Slides.IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 50, 100, 100, slide2);

            // Remove the background from the second zoom frame
            zoomFrame2.ShowBackground = false;

            // Save the presentation
            pres.Save("RemoveZoomBackground_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}