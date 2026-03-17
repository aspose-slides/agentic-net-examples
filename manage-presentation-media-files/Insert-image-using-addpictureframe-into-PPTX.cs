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

            // Open image file stream
            FileStream imageStream = new FileStream("example.png", FileMode.Open, FileAccess.Read);

            // Add image to the presentation resources
            Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream, LoadingStreamBehavior.KeepLocked);
            imageStream.Dispose();

            // Add picture frame to the first slide
            IShapeCollection shapes = presentation.Slides[0].Shapes;
            IPictureFrame pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 50f, 50f, 400f, 300f, image);

            // Save the presentation
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}