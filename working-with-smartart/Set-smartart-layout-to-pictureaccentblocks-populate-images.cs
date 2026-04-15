using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();
            ISlide slide = pres.Slides[0];

            // Add SmartArt with PictureAccentBlocks layout
            ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureAccentBlocks);

            // Paths to images to populate the SmartArt nodes
            string[] imagePaths = new string[]
            {
                "image1.jpg",
                "image2.jpg",
                "image3.jpg",
                "image4.jpg"
            };

            int imgIndex = 0;
            foreach (ISmartArtNode node in smartArt.Nodes)
            {
                if (imgIndex >= imagePaths.Length)
                    break;

                string imgPath = imagePaths[imgIndex];

                // Check if the image file exists
                if (!File.Exists(imgPath))
                {
                    // Skip missing files
                    imgIndex++;
                    continue;
                }

                // Load image into the presentation
                byte[] imgData = File.ReadAllBytes(imgPath);
                IPPImage img = pres.Images.AddImage(imgData);

                // Apply the image as picture fill to the first shape of the node
                if (node.Shapes.Count > 0)
                {
                    IShape shape = node.Shapes[0];
                    shape.FillFormat.PictureFillFormat.Picture.Image = img;
                }

                imgIndex++;
            }

            // Save the presentation
            try
            {
                pres.Save("SmartArtPictureAccentBlocks.pptx", SaveFormat.Pptx);
            }
            catch (Exception)
            {
                // Format not supported
            }
        }
    }
}