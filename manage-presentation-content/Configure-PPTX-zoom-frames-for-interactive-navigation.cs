using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a second slide to serve as the zoom target
            Aspose.Slides.ISlide targetSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Add a zoom frame on the first slide referencing the second slide
            Aspose.Slides.IZoomFrame zoomFrame = presentation.Slides[0].Shapes.AddZoomFrame(150f, 20f, 100f, 100f, targetSlide);

            // Set the zoom frame image type to preview (optional)
            zoomFrame.ImageType = Aspose.Slides.ZoomImageType.Preview;

            // Save the presentation
            presentation.Save("ZoomPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}