using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        var slide = presentation.Slides[0];

        // Load an image from file
        using (var imageStream = new FileStream("image.png", FileMode.Open, FileAccess.Read))
        {
            // Add the image to the presentation's image collection
            Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

            // Add a picture frame to the slide using the image
            Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                50,    // X position (points)
                50,    // Y position (points)
                300,   // Width (points)
                200,   // Height (points)
                image);
        }

        // Save the presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}