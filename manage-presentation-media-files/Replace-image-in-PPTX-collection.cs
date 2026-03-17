using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceImageExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths to the input and output presentation files
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                // Load the presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Get the collection of images in the presentation
                    Aspose.Slides.IImageCollection images = pres.Images;

                    // Ensure there are at least two images to perform replacement
                    if (images.Count < 2)
                    {
                        Console.WriteLine("The presentation does not contain enough images for replacement.");
                        return;
                    }

                    // Source image (the image that will be used for replacement)
                    Aspose.Slides.IPPImage sourceImage = images[0];

                    // Target image (the image that will be replaced)
                    Aspose.Slides.IPPImage targetImage = images[1];

                    // Replace the target image data with the source image data
                    targetImage.ReplaceImage(sourceImage);

                    // Save the modified presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("Image replacement completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}