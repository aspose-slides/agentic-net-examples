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

            // Path to the image file to be added
            string imagePath = "image.png";

            // Open the image file as a stream
            using (FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                // Add the image to the presentation's image collection
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(fileStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

                // Insert the image into a picture frame on the first slide
                Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;
                shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 0, 0, 300, 200, image);
            }

            // Save the presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}