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

            // Verify input image exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Input image not found: " + imagePath);
                return;
            }

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle shape
                IAutoShape rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 300);

                // Set picture fill type
                rectangle.FillFormat.FillType = FillType.Picture;

                // Load image and add to presentation images
                IImage image = Images.FromFile(imagePath);
                IPPImage ppImage = presentation.Images.AddImage(image);

                // Assign image to picture fill
                IPictureFillFormat pictureFill = rectangle.FillFormat.PictureFillFormat;
                pictureFill.Picture.Image = ppImage;

                // Crop the picture within the shape (values are percentages as fractions)
                pictureFill.CropTop = 0.1f;    // Crop 10% from top
                pictureFill.CropBottom = 0.1f; // Crop 10% from bottom
                pictureFill.CropLeft = 0.05f;  // Crop 5% from left
                pictureFill.CropRight = 0.05f; // Crop 5% from right

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}