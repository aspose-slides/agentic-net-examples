using System;
using System.IO;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace ApplyPictureFillToSmartArtNode
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a SmartArt diagram to the first slide
            ISlide slide = pres.Slides[0];
            ISmartArt smartArt = slide.Shapes.AddSmartArt(0f, 0f, 400f, 400f, SmartArtLayoutType.BasicBlockList);

            // Ensure the SmartArt has at least one node and one shape
            if (smartArt.Nodes.Count > 0 && smartArt.Nodes[0].Shapes.Count > 0)
            {
                // Get the first shape of the first node
                ISmartArtShape smartShape = smartArt.Nodes[0].Shapes[0];

                // Download image from external web service
                byte[] imageBytes = null;
                try
                {
                    HttpClient client = new HttpClient();
                    // Replace with a valid image URL
                    string imageUrl = "https://example.com/sample-image.jpg";
                    HttpResponseMessage response = client.GetAsync(imageUrl).Result;
                    response.EnsureSuccessStatusCode();
                    imageBytes = response.Content.ReadAsByteArrayAsync().Result;
                }
                catch (Exception ex)
                {
                    // Handle web service errors
                    Console.WriteLine("Error downloading image: " + ex.Message);
                }

                if (imageBytes != null)
                {
                    // Add the image to the presentation's image collection
                    IPPImage ippImage = pres.Images.AddImage(imageBytes);

                    // Apply picture fill to the SmartArt shape
                    smartShape.FillFormat.PictureFillFormat.Picture.Image = ippImage;
                }
            }

            // Save the presentation
            try
            {
                pres.Save("SmartArtPictureFill.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other save errors
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}