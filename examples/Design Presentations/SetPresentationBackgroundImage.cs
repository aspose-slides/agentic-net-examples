using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetPresentationBackgroundImage
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDir = Directory.GetCurrentDirectory();
            string imagePath = Path.Combine(dataDir, "background.jpg");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Set slide background to use a picture
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Picture;
            slide.Background.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;

            // Load image and add it to the presentation's image collection
            Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);
            Aspose.Slides.IPPImage pptImg = presentation.Images.AddImage(img);

            // Assign the image to the slide background
            slide.Background.FillFormat.PictureFillFormat.Picture.Image = pptImg;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}