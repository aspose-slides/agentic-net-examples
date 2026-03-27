using System;
using System.IO;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // URL of the image to retrieve from a web service
            const string imageUrl = "https://example.com/sample-image.jpg";

            // Output presentation file
            const string outputPath = "SmartArtPictureFill.pptx";

            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a SmartArt diagram to the slide
                Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                    0f, 0f, 400f, 400f,
                    Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

                // Retrieve the first node of the SmartArt
                Aspose.Slides.SmartArt.ISmartArtNode firstNode = smartArt.Nodes[0];

                // Retrieve the first shape within the node
                Aspose.Slides.SmartArt.ISmartArtShape firstShape = firstNode.Shapes[0];

                // Download image data from the external web service
                byte[] imageBytes = null;
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        imageBytes = httpClient.GetByteArrayAsync(imageUrl).Result;
                    }
                }
                catch (Exception ex)
                {
                    // Handle errors related to the web request (e.g., network issues)
                    Console.WriteLine("Error downloading image: " + ex.Message);
                    // Exit if image cannot be retrieved
                    return;
                }

                // Add the downloaded image to the presentation's image collection
                Aspose.Slides.IPPImage ippImage = null;
                try
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        ippImage = pres.Images.AddImage(ms);
                    }
                }
                catch (Exception ex)
                {
                    // Handle errors related to unsupported image formats
                    Console.WriteLine("Error adding image to presentation (format not supported): " + ex.Message);
                    return;
                }

                // Apply picture fill to the SmartArt shape using the retrieved image
                // Correct pattern: use FillFormat.PictureFillFormat.Picture.Image
                firstShape.FillFormat.PictureFillFormat.Picture.Image = ippImage;

                // Save the presentation
                try
                {
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    // Handle errors that may occur during saving
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}