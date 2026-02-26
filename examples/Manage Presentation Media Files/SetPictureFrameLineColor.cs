using System;
using System.Drawing;
using System.IO;

class Program
{
    static void Main()
    {
        // Paths for the source image and the output presentation
        string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "example.jpg");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Load the image from file
        Aspose.Slides.IImage image = Aspose.Slides.Images.FromFile(imagePath);

        // Add the image to the presentation's image collection
        Aspose.Slides.IPPImage imgx = presentation.Images.AddImage(image);

        // Add a picture frame containing the image
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            50f,               // X position
            50f,               // Y position
            imgx.Width,        // Width of the picture frame
            imgx.Height,       // Height of the picture frame
            imgx);

        // Set line formatting: solid blue line with a width of 5 points
        pictureFrame.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
        pictureFrame.LineFormat.Width = 5f;

        // No rotation applied
        pictureFrame.Rotation = 0f;

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}