using System;
using System.IO;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output presentation file path
            string outputPath = "EllipsePictureFill.pptx";

            // Image URL to be used for picture fill
            string imageUrl = "https://example.com/image.jpg";

            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add an ellipse shape
            IShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 300, 200);

            // Download image from URL
            byte[] imageBytes = null;
            try
            {
                HttpClient client = new HttpClient();
                imageBytes = client.GetByteArrayAsync(imageUrl).Result;
                client.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to download image: " + ex.Message);
            }

            // Verify that the image was loaded correctly
            if (imageBytes != null && imageBytes.Length > 0)
            {
                // Add image to presentation's image collection
                IPPImage ppImg = pres.Images.AddImage(imageBytes);

                // Apply picture fill to the ellipse
                ellipse.FillFormat.FillType = FillType.Picture;
                IPictureFillFormat picFill = ellipse.FillFormat.PictureFillFormat;
                picFill.Picture.Image = ppImg;
                picFill.PictureFillMode = PictureFillMode.Stretch;
            }
            else
            {
                Console.WriteLine("Image data is empty or could not be retrieved.");
            }

            // Save the presentation
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Format not supported or other save error
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }

            // Dispose presentation
            pres.Dispose();
        }
    }
}