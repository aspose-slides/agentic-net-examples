using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the image file to be added
        string imagePath = "image.png";

        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Add the image to the presentation's image collection
            Aspose.Slides.IPPImage img;
            using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                img = pres.Images.AddImage(fs, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
            }

            // Add a picture frame shape to the first slide using the added image
            Aspose.Slides.IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle, 0, 0, 300, 200, img);

            // Save the presentation
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}