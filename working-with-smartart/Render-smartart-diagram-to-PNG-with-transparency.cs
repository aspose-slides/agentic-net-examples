using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtRender
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory and ensure it exists
            string outputDirectory = "Data";
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Define paths for the generated image and presentation
            string imagePath = Path.Combine(outputDirectory, "smartart.png");
            string presentationPath = Path.Combine(outputDirectory, "presentation.pptx");

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Set slide background to transparent (no fill)
                slide.Background.Type = BackgroundType.OwnBackground;
                slide.Background.FillFormat.FillType = FillType.NoFill;

                // Add a SmartArt diagram to the slide
                ISmartArt smartArt = slide.Shapes.AddSmartArt(
                    0f,
                    0f,
                    400f,
                    400f,
                    SmartArtLayoutType.BasicBlockList);

                // Render the SmartArt shape to an image
                IImage smartArtImage = smartArt.GetImage();

                // Save the image as PNG with transparent background
                smartArtImage.Save(imagePath, Aspose.Slides.ImageFormat.Png);

                // Save the presentation file
                presentation.Save(presentationPath, SaveFormat.Pptx);
            }
        }
    }
}