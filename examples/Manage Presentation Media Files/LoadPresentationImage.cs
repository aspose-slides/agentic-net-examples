using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Path to the image file to be added
        string imagePath = "image.jpg";
        // Path where the resulting PPTX will be saved
        string outputPath = "output.pptx";

        // Load the image file into a byte array
        byte[] imageData = File.ReadAllBytes(imagePath);

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add the image to the presentation's image collection
        Aspose.Slides.IPPImage img = pres.Images.AddImage(imageData);

        // Insert the image as a picture frame on the first slide
        pres.Slides[0].Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            0,
            0,
            pres.SlideSize.Size.Width,
            pres.SlideSize.Size.Height,
            img);

        // Save the presentation in PPTX format
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        pres.Dispose();
    }
}