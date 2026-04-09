using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AdjustPictureCrop
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Get first slide
                ISlide slide = presentation.Slides[0];

                // Get first picture frame on the slide
                IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;
                if (pictureFrame != null)
                {
                    // Get the original image dimensions
                    IPPImage image = pictureFrame.PictureFormat.Picture.Image;
                    float imageWidth = image.Width;
                    float imageHeight = image.Height;

                    // Adjust crop margins to achieve a square view
                    if (imageWidth > imageHeight)
                    {
                        // Crop left and right equally
                        float excessRatio = (imageWidth - imageHeight) / imageWidth;
                        float cropPercent = excessRatio * 100f;
                        pictureFrame.PictureFormat.CropLeft = cropPercent / 2f;
                        pictureFrame.PictureFormat.CropRight = cropPercent / 2f;
                    }
                    else if (imageHeight > imageWidth)
                    {
                        // Crop top and bottom equally
                        float excessRatio = (imageHeight - imageWidth) / imageHeight;
                        float cropPercent = excessRatio * 100f;
                        pictureFrame.PictureFormat.CropTop = cropPercent / 2f;
                        pictureFrame.PictureFormat.CropBottom = cropPercent / 2f;
                    }
                    // If dimensions are equal, no cropping needed
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}