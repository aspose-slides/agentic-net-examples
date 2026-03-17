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
            // Path to the large image file
            string sourceImagePath = "large_image.jpg";
            // Path where the presentation will be saved
            string outputPath = "presentationWithLargeImage.pptx";

            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Open the image file as a stream
                using (FileStream imageStream = new FileStream(sourceImagePath, FileMode.Open, FileAccess.Read))
                {
                    // Add the image to the presentation using KeepLocked behavior to avoid loading the whole image into memory
                    Aspose.Slides.IPPImage image = pres.Images.AddImage(imageStream, LoadingStreamBehavior.KeepLocked);
                    // Insert the image into the first slide as a picture frame
                    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image);
                }

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}