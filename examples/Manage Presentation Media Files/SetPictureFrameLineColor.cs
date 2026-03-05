using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Load an image from file
        string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "sample.jpg");
        Aspose.Slides.IImage image = Aspose.Slides.Images.FromFile(imagePath);
        Aspose.Slides.IPPImage imgx = presentation.Images.AddImage(image);

        // Add a picture frame containing the image
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            50, 50,
            imgx.Width, imgx.Height,
            imgx);

        // Set the line color of the picture frame to Red and define line width
        pictureFrame.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
        pictureFrame.LineFormat.Width = 5;

        // Save the presentation
        presentation.Save("SetPictureFrameLineColor_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}