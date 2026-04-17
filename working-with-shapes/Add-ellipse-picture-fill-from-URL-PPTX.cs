using System;
using System.IO;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Add an ellipse shape
        IShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 300, 200);

        // URL of the picture to use as fill
        string imageUrl = "https://example.com/image.jpg";

        // Download the image and add it to the presentation
        IPPImage pictureImage = null;
        try
        {
            using (HttpClient client = new HttpClient())
            {
                byte[] imageBytes = client.GetByteArrayAsync(imageUrl).Result;
                pictureImage = pres.Images.AddImage(imageBytes);
            }
        }
        catch (HttpRequestException)
        {
            // Handle URL download exception
            Console.WriteLine("Failed to download image from URL.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., unsupported format)
            Console.WriteLine("Error loading image: " + ex.Message);
        }

        if (pictureImage != null)
        {
            // Apply picture fill to the ellipse
            ellipse.FillFormat.FillType = FillType.Picture;
            IPictureFillFormat picFill = ellipse.FillFormat.PictureFillFormat;
            picFill.Picture.Image = pictureImage;
        }

        // Save the presentation
        string outPath = "EllipseWithPictureFill.pptx";
        pres.Save(outPath, SaveFormat.Pptx);
    }
}