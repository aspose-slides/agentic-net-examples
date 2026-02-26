using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentationMediaFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string imageFileName = "heading.jpg"; // replace with your image file name
            string imagePath = Path.Combine(dataDirectory, imageFileName);
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "SlideWithBackground.pptx");

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Load image into Aspose.Slides IImage (avoids System.Drawing.Image)
            Aspose.Slides.IImage asposeImage = Aspose.Slides.Images.FromFile(imagePath);

            // Add image to the presentation's image collection
            Aspose.Slides.IPPImage ipPImage = presentation.Images.AddImage(asposeImage);

            // Set slide background to use the added image
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Picture;
            slide.Background.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;
            slide.Background.FillFormat.PictureFillFormat.Picture.Image = ipPImage;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}