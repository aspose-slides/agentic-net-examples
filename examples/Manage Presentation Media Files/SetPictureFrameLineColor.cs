using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Load an image from file and add it to the presentation's image collection
        FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read);
        Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);
        imageStream.Close();

        // Add a picture frame to the slide
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
            ShapeType.Rectangle, // shape type
            100,                 // X position (points)
            100,                 // Y position (points)
            300,                 // width (points)
            200,                 // height (points)
            image);              // image to display

        // Set the line (border) color of the picture frame to red
        pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
        pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

        // Save the presentation to a file
        presentation.Save("output.pptx", SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}