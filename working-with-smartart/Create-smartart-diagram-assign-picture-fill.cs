using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtPictureFillExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // List of image file paths to be used for picture fill
            string[] imagePaths = new string[]
            {
                "image1.jpg",
                "image2.jpg",
                "image3.jpg"
            };

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a SmartArt diagram to the slide
                ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

                // Index to track which image to use
                int imageIndex = 0;

                // Iterate through each root node of the SmartArt
                foreach (ISmartArtNode node in smartArt.Nodes)
                {
                    if (imageIndex >= imagePaths.Length)
                        break; // No more images available

                    string imagePath = imagePaths[imageIndex];

                    // Verify that the image file exists
                    if (!File.Exists(imagePath))
                    {
                        // Skip missing files
                        imageIndex++;
                        continue;
                    }

                    try
                    {
                        // Load image bytes and add to the presentation's image collection
                        byte[] imageBytes = File.ReadAllBytes(imagePath);
                        IPPImage ippImage = presentation.Images.AddImage(imageBytes);

                        // Assign picture fill to the first shape of the node
                        if (node.Shapes.Count > 0)
                        {
                            ISmartArtShape shape = node.Shapes[0];
                            shape.FillFormat.PictureFillFormat.Picture.Image = ippImage;
                        }
                    }
                    catch (Exception)
                    {
                        // Handle unsupported image format or other errors
                        // Format not supported – continue with next image
                    }

                    imageIndex++;
                }

                // Save the presentation
                presentation.Save("SmartArtPictureFill.pptx", SaveFormat.Pptx);
            }
        }
    }
}