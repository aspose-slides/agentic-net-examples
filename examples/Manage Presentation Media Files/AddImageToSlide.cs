using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the local image file
        string imagePath = "image.jpg";

        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Open the image file as a stream
            using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                // Add the image to the presentation's image collection
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

                // Insert the image onto the first slide as a picture frame
                presentation.Slides[0].Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300, image);
            }

            // Save the presentation to a PPTX file
            presentation.Save("PresentationWithImage.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}