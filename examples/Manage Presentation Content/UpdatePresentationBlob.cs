using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BLOBPresentationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the large image that will be added as a BLOB.
            string imagePath = "large_image.jpg";

            // Create a new presentation.
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Open the image file as a stream.
                using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    // Add the image to the presentation using KeepLocked behavior to minimize memory usage.
                    Aspose.Slides.IPPImage img = pres.Images.AddImage(imageStream, LoadingStreamBehavior.KeepLocked);

                    // Insert the image onto the first slide.
                    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);
                }

                // Save the presentation in PPT format before exiting.
                pres.Save("BLOBPresentation.ppt", SaveFormat.Ppt);
            }
        }
    }
}