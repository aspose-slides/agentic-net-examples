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
            using (Presentation presentation = new Presentation())
            {
                // Path to the image file
                string imagePath = "sample.jpg";

                // Add the image to the presentation
                using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    IPPImage image = presentation.Images.AddImage(imageStream, LoadingStreamBehavior.KeepLocked);
                    // Insert a picture frame on the first slide
                    presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50f, 50f, 400f, 300f, image);
                }

                // Save the presentation in PPTX format
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}