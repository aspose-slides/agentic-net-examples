using System;
using System.IO;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertWebImageIntoHeading
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // URL of the online image
                string imageUrl = "https://example.com/image.png";

                // Download image bytes
                HttpClient httpClient = new HttpClient();
                byte[] imageBytes = httpClient.GetByteArrayAsync(imageUrl).Result;

                // Add image to the presentation's image collection using the byte[] overload
                Aspose.Slides.IPPImage ippImage = presentation.Images.AddImage(imageBytes);

                // Add a picture frame (as a heading placeholder) to the slide
                // Adjust position and size as needed
                Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    50,   // X position
                    50,   // Y position
                    300,  // Width
                    200,  // Height
                    ippImage);

                // Save the presentation
                presentation.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}