using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Load an image from file
        FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read);
        Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);
        imageStream.Close();

        // Add a picture frame to the slide
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 150, image);

        // Rotate the picture frame clockwise by 45 degrees (positive value)
        pictureFrame.Rotation = 45f;

        // Save the presentation
        presentation.Save("RotatedPicture.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}