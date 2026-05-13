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

        // URL of the picture to fill
        string imageUrl = "https://example.com/image.jpg";

        // Download the image data
        byte[] imageBytes = null;
        try
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(imageUrl).Result;
                response.EnsureSuccessStatusCode();
                imageBytes = response.Content.ReadAsByteArrayAsync().Result;
            }
        }
        catch (Exception ex)
        {
            // Handle download errors
            Console.WriteLine("Failed to download image: " + ex.Message);
        }

        // Verify that the image was loaded successfully
        if (imageBytes != null && imageBytes.Length > 0)
        {
            // Add the image to the presentation's image collection
            IPPImage ppImage = pres.Images.AddImage(imageBytes);

            // Apply picture fill to the ellipse
            ellipse.FillFormat.FillType = FillType.Picture;
            IPictureFillFormat picFill = ellipse.FillFormat.PictureFillFormat;
            picFill.Picture.Image = ppImage;
            picFill.PictureFillMode = PictureFillMode.Stretch;
        }
        else
        {
            // Image could not be loaded; skipping picture fill.
        }

        // Save the presentation
        string outPath = "EllipsePictureFill.pptx";
        pres.Save(outPath, SaveFormat.Pptx);
    }
}