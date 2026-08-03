// -----------------------------------------------------------------------------
// Example: Adjust crop margins to square picture frame using C#
//
// Description:
// Demonstrates how to adjust crop margins of a picture frame to obtain a square
// view using C# and Aspose.Slides for .NET. The example loads a PPTX file,
// identifies the first picture on the first slide, calculates the necessary
// crop percentages, applies them, and saves the modified presentation.
// This pattern helps automate image cropping within PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Adjust Crop, Square Picture Frame,
// Image Cropping, Presentation Processing, Office Automation
//
// Use Cases:
// - Automatically crop pictures to a square aspect ratio in presentations.
// - Build C# utilities for batch processing of PPTX files.
// - Integrate image adjustment logic into .NET applications that handle slides.
// - Ensure consistent visual layout of pictures before publishing.
// -----------------------------------------------------------------------------
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
