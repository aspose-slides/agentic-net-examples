using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace UpdateHeadingImages
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation, new heading image, and output file paths
            string inputPresentationPath = "input.pptx";
            string newHeadingImagePath = "newHeading.png";
            string outputPresentationPath = "output.pptx";

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPresentationPath))
                {
                    // Read the new image data once
                    byte[] newImageData = File.ReadAllBytes(newHeadingImagePath);
                    // Add the new image to the presentation's image collection
                    IPPImage newImg = pres.Images.AddImage(newImageData);

                    // Iterate through all slides and shapes
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];
                            // Check if the shape is a picture frame (heading image)
                            if (shape is IPictureFrame)
                            {
                                IPictureFrame pictureFrame = (IPictureFrame)shape;
                                // Replace the picture frame's image with the new image
                                pictureFrame.PictureFormat.Picture.Image = newImg;
                            }
                        }
                    }

                    // Save the updated presentation
                    pres.Save(outputPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}