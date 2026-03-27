using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace ReplacePicturePlaceholders
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output presentation paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // High‑resolution photos to insert
            string[] photoPaths = new string[]
            {
                "photo1.jpg",
                "photo2.jpg",
                "photo3.jpg"
            };

            // Ensure the input file exists; if not, create a new presentation
            Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Presentation(inputPath);
            }
            else
            {
                presentation = new Presentation();
            }

            // Add a picture organization chart SmartArt to the first slide
            ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
                50, 50, 600, 400, SmartArtLayoutType.PictureOrganizationChart);

            // Insert photos into the slide, positioning them manually
            float pictureX = 100;
            float pictureY = 100;
            float pictureWidth = 150;
            float pictureHeight = 150;

            foreach (string photoPath in photoPaths)
            {
                if (!File.Exists(photoPath))
                {
                    continue; // Skip missing photos
                }

                // Add the image to the presentation's image collection
                byte[] imageBytes = File.ReadAllBytes(photoPath);
                IPPImage image = presentation.Images.AddImage(imageBytes);

                // Add a picture frame using the added image
                presentation.Slides[0].Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    pictureX, pictureY, pictureWidth, pictureHeight, image);

                // Update position for the next picture
                pictureX += pictureWidth + 20;
                if (pictureX + pictureWidth > presentation.SlideSize.Size.Width)
                {
                    pictureX = 100;
                    pictureY += pictureHeight + 20;
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}