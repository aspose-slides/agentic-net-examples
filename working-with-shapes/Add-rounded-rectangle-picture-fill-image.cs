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
            // Path to the external image file
            string imagePath = "sample_image.jpg";

            // Verify that the image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Load image bytes and add it to the presentation's image collection
                byte[] imageBytes;
                try
                {
                    imageBytes = File.ReadAllBytes(imagePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to read image file: " + ex.Message);
                    return;
                }

                IPPImage ippImage;
                try
                {
                    ippImage = presentation.Images.AddImage(imageBytes);
                }
                catch (Exception ex)
                {
                    // Handle unsupported image format
                    Console.WriteLine("Unsupported image format: " + ex.Message);
                    return;
                }

                // Add a rectangle shape (used as a rounded rectangle placeholder)
                IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 200);

                // Set the shape's fill type to picture and apply the loaded image
                rectangleShape.FillFormat.FillType = FillType.Picture;
                rectangleShape.FillFormat.PictureFillFormat.Picture.Image = ippImage;

                // Optionally, adjust corner radius to simulate a rounded rectangle
                // (Aspose.Slides does not expose a direct property; this is a placeholder for custom geometry if needed)

                // Save the presentation
                try
                {
                    presentation.Save("RoundedRectanglePictureFill.pptx", SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to save presentation: " + ex.Message);
                }
            }
        }
    }
}