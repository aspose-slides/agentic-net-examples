using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Paths for the source image and the output presentation
        string dataDir = "Data";
        string imagePath = Path.Combine(dataDir, "example.jpg");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Load the image from file
        Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);

        // Add the image to the presentation's image collection
        Aspose.Slides.IPPImage ppImg = pres.Images.AddImage(img);

        // Add a picture frame containing the image
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            50f,               // X position
            50f,               // Y position
            ppImg.Width,       // Width of the picture frame
            ppImg.Height,      // Height of the picture frame
            ppImg);            // Image to display

        // Format the picture frame border: solid blue line with width 2
        pictureFrame.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
        pictureFrame.LineFormat.Width = 2f;

        // Rotate the picture frame by 15 degrees
        pictureFrame.Rotation = 15f;

        // Save the presentation in PPTX format
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}