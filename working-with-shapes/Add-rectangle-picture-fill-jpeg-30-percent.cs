using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string imagePath = "externalImage.jpg";

            // Verify that the image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            try
            {
                // Load the JPEG image into a stream
                using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a rectangle shape
                    IAutoShape rectangle = slide.Shapes.AddAutoShape(
                        ShapeType.Rectangle, 50, 50, 400, 300);

                    // Set the fill type to picture
                    rectangle.FillFormat.FillType = FillType.Picture;

                    // Add the image to the presentation's image collection
                    IPPImage pictureImage = presentation.Images.AddImage(imageStream);

                    // Assign the image to the rectangle's picture fill
                    rectangle.FillFormat.PictureFillFormat.Picture.Image = pictureImage;

                    // Apply 30% transparency using Alpha Modulate Fixed effect
                    IImageTransformOperationCollection imgTransform = rectangle.FillFormat.PictureFillFormat.Picture.ImageTransform;
                    imgTransform.AddAlphaModulateFixedEffect(0.3f);

                    // Save the presentation
                    presentation.Save("RectangleWithTransparentImage.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided image format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}