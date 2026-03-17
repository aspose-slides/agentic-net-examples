using System;
using System.IO;
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

            // Add a second slide to serve as the target of the zoom frame
            Aspose.Slides.ISlide targetSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Load a custom image from file
            byte[] imageData = File.ReadAllBytes("customImage.png");
            Aspose.Slides.IPPImage customImage = presentation.Images.AddImage(imageData);

            // Add a zoom frame on the first slide with the custom image
            Aspose.Slides.IZoomFrame zoomFrame = presentation.Slides[0].Shapes.AddZoomFrame(150, 20, 100, 100, targetSlide, customImage);
            zoomFrame.ImageType = Aspose.Slides.ZoomImageType.Cover;
            zoomFrame.ReturnToParent = true;

            // Save the presentation
            presentation.Save("ZoomPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}