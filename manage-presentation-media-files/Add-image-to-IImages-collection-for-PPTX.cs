using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the image file to be added
            string imagePath = "image.jpg";

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add the image to the presentation's image collection
            Aspose.Slides.IPPImage img;
            using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                img = pres.Images.AddImage(fs, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
            }

            // Insert a picture frame shape using the added image
            Aspose.Slides.IShapeCollection shapes = pres.Slides[0].Shapes;
            shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 50f, 50f, 300f, 200f, img);

            // Save the presentation
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}