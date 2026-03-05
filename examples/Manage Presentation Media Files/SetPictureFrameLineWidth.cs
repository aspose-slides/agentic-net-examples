using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Load an image from file
        FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read);
        Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);
        imageStream.Close();

        // Add a picture frame to the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 150, image);

        // Set the line width of the picture frame
        pictureFrame.LineFormat.Width = 5.0;

        // Save the presentation
        presentation.Save("output.pptx", SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}