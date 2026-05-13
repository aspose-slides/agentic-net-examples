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
            string imagePath = Path.Combine(dataDir, "image.jpg");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Ensure data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Check if the input image exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Input image file not found: " + imagePath);
                return;
            }

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Load the image
                IImage img = Images.FromFile(imagePath);
                IPPImage ppImg = presentation.Images.AddImage(img);

                // Add a rectangle shape
                IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 300);

                // Apply picture fill to the rectangle
                shape.FillFormat.FillType = FillType.Picture;
                IPictureFillFormat picFill = shape.FillFormat.PictureFillFormat;
                picFill.Picture.Image = ppImg;

                // Crop the picture within the shape to focus on a region
                picFill.CropTop = 0.1f;    // Crop 10% from top
                picFill.CropBottom = 0.1f; // Crop 10% from bottom
                picFill.CropLeft = 0.2f;   // Crop 20% from left
                picFill.CropRight = 0.2f;  // Crop 20% from right

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}