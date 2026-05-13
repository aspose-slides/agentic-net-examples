using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

namespace AddRectangleJpegPictureFill30Pct
{
    class Program
    {
        static void Main(string[] args)
        {
            string imagePath = "sample.jpg";
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation())
                {
                    ISlide slide = presentation.Slides[0];

                    // Add a rectangle shape
                    IAutoShape rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 300);

                    // Load JPEG image from file stream
                    byte[] imageBytes = File.ReadAllBytes(imagePath);
                    IPPImage pictureImage = presentation.Images.AddImage(imageBytes);

                    // Set picture fill
                    rectangle.FillFormat.FillType = FillType.Picture;
                    rectangle.FillFormat.PictureFillFormat.Picture.Image = pictureImage;

                    // Adjust picture fill transparency to 30%
                    rectangle.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(30f);

                    // Save the presentation
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}