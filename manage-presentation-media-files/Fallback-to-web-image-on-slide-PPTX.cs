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
            try
            {
                // Path to the local image file
                string localImagePath = "image.png";
                // URL of the image to download if local file is unavailable
                string imageUrl = "https://example.com/image.png";

                byte[] imageData;

                // Attempt to read the image from the local file system
                try
                {
                    imageData = File.ReadAllBytes(localImagePath);
                }
                catch (Exception)
                {
                    // If reading fails, download the image from the web
                    using (HttpClient httpClient = new HttpClient())
                    {
                        imageData = httpClient.GetByteArrayAsync(imageUrl).Result;
                    }
                }

                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Add the image to the presentation's image collection
                    IPPImage pictureImage = presentation.Images.AddImage(imageData);

                    // Insert the picture onto the first slide
                    presentation.Slides[0].Shapes.AddPictureFrame(
                        ShapeType.Rectangle,
                        0,          // X position
                        0,          // Y position
                        300,        // Width
                        200,        // Height
                        pictureImage);

                    // Save the presentation
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}