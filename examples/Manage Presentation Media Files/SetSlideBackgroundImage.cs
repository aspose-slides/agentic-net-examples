using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory and ensure it exists
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);

            // Path to the background image file
            string imagePath = Path.Combine(dataDir, "background.jpg");

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Set slide background to use a picture
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Picture;
            slide.Background.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;

            // Load image and add it to the presentation's image collection
            Aspose.Slides.IImage image = Aspose.Slides.Images.FromFile(imagePath);
            Aspose.Slides.IPPImage pptImage = presentation.Images.AddImage(image);

            // Assign the image to the slide background
            slide.Background.FillFormat.PictureFillFormat.Picture.Image = pptImage;

            // Save the presentation
            string outputPath = Path.Combine(dataDir, "output.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}