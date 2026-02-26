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

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Set the background to use an image
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Picture;
        slide.Background.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;

        // Load the image from file (replace "background.jpg" with your image file name)
        string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "background.jpg");
        Aspose.Slides.IImage image = Aspose.Slides.Images.FromFile(imagePath);
        Aspose.Slides.IPPImage imgx = presentation.Images.AddImage(image);

        // Assign the image to the slide background
        slide.Background.FillFormat.PictureFillFormat.Picture.Image = imgx;

        // Save the presentation
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "ImageBackground.pptx");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}