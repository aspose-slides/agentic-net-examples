using System;
using System.IO;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first master slide
            Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

            // Load image bytes from file
            byte[] imageBytes = File.ReadAllBytes("background.jpg");

            // Add the image to the presentation's image collection
            Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageBytes);

            // Set the master slide background to use the image
            masterSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            masterSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Picture;
            masterSlide.Background.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;
            masterSlide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

            // Save the presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}