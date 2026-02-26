using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // URL of the image to download
            string imageUrl = "https://example.com/image.jpg";

            // Download image data
            using (HttpClient httpClient = new HttpClient())
            {
                byte[] imageBytes = httpClient.GetByteArrayAsync(imageUrl).Result;

                // Add image to the presentation
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageBytes);

                // Add picture frame to the slide
                slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300, image);
            }

            // Save the presentation
            presentation.Save("PresentationWithWebImage.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}