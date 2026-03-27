using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace ConfigureSmartArtPictureAccentBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            // Directory containing images
            string imagesDir = "Images";

            // Verify the directory exists
            if (!Directory.Exists(imagesDir))
            {
                Console.WriteLine("Images directory does not exist: " + imagesDir);
                return;
            }

            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add SmartArt with PictureAccentBlocks layout
                ISmartArt smartArt = slide.Shapes.AddSmartArt(
                    0f, 0f, 400f, 400f,
                    SmartArtLayoutType.PictureAccentBlocks);

                // Iterate over image files in the directory
                string[] imageFiles = Directory.GetFiles(imagesDir);
                foreach (string imagePath in imageFiles)
                {
                    // Load image bytes
                    byte[] imageBytes = File.ReadAllBytes(imagePath);

                    // Add image to presentation's image collection
                    IPPImage pptImage = pres.Images.AddImage(imageBytes);

                    // Add a new node to the SmartArt
                    ISmartArtNode node = smartArt.Nodes.AddNode();

                    // Each node contains at least one shape; get the first shape
                    ISmartArtShape shape = node.Shapes[0];

                    // Set picture fill for the shape
                    shape.FillFormat.FillType = FillType.Picture;
                    shape.FillFormat.PictureFillFormat.Picture.Image = pptImage;
                }

                // Save the presentation
                pres.Save("SmartArtPictureAccentBlocks.pptx", SaveFormat.Pptx);
            }
        }
    }
}