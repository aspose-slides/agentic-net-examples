using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string imageFileName = "sample.jpg";
            string imagePath = Path.Combine(dataDir, imageFileName);
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Ensure data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Verify input image exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Input image not found: " + imagePath);
                return;
            }

            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Load image and add to presentation resources
                IImage img = Images.FromFile(imagePath);
                IPPImage ppImg = pres.Images.AddImage(img);

                // Add a picture frame with the image dimensions
                IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                    ShapeType.Rectangle,
                    100f, // X position
                    100f, // Y position
                    ppImg.Width,
                    ppImg.Height,
                    ppImg);

                // Set fill to picture and stretch mode
                pictureFrame.FillFormat.FillType = FillType.Picture;
                pictureFrame.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

                // Lock aspect ratio to preserve it during stretch
                pictureFrame.PictureFrameLock.AspectRatioLocked = true;

                // Verify that aspect ratio remains unchanged
                float imageAspect = (float)ppImg.Width / ppImg.Height;
                float frameAspect = pictureFrame.Width / pictureFrame.Height;
                // If the aspect ratios differ significantly, it indicates a problem
                if (Math.Abs(imageAspect - frameAspect) > 0.01f)
                {
                    Console.WriteLine("Warning: Aspect ratio may have changed.");
                }

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}