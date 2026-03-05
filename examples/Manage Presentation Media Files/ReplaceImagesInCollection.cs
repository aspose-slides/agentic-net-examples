using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceImagesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to the source presentation, the new image, and the output file
            string sourcePresentationPath = "input.pptx";
            string newImagePath = "newImage.png";
            string outputPresentationPath = "output.pptx";

            // Load the new image data into a byte array
            byte[] newImageData = File.ReadAllBytes(newImagePath);

            // Open the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePresentationPath))
            {
                // Iterate through all images in the presentation
                for (int i = 0; i < presentation.Images.Count; i++)
                {
                    // Get the image at the current index
                    Aspose.Slides.IPPImage image = presentation.Images[i];

                    // Replace the image data with the new image
                    image.ReplaceImage(newImageData);
                }

                // Save the modified presentation
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
            }
        }
    }
}