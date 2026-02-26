using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Path to the image file to be added
        string imagePath = "sample.jpg";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add the image to the presentation's image collection
        Aspose.Slides.IPPImage image;
        using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
        {
            image = presentation.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
        }

        // Insert the image onto the first slide as a picture frame
        Aspose.Slides.IShape pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            50, 50, 400, 300,
            image);

        // Save the presentation to a PPTX file
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}