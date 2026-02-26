using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define data directory and ensure it exists
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(dataDir))
            Directory.CreateDirectory(dataDir);

        // Input image path (replace with actual image file name)
        string imagePath = Path.Combine(dataDir, "image.jpg");
        // Output presentation path
        string outPath = Path.Combine(dataDir, "output.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Load the image from file
        Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);
        // Add the image to the presentation's image collection
        Aspose.Slides.IPPImage imgx = presentation.Images.AddImage(img);

        // Add a picture frame using the image's original width and height
        Aspose.Slides.IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            0, 0,
            imgx.Width,
            imgx.Height,
            imgx);

        // Save the presentation in PPTX format
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}