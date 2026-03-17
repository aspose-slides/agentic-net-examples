using System;
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Paths
            string outputPath = "WebImagePresentation.pptx";
            string imageUrl = "https://example.com/sample-image.jpg";

            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Download image data from the web
                using (WebClient client = new WebClient())
                {
                    byte[] imageData = client.DownloadData(imageUrl);

                    // Add the image to the presentation using the byte[] overload
                    IPPImage img = pres.Images.AddImage(imageData);

                    // Define position and size (in points)
                    float pictureX = 50f;   // X-coordinate
                    float pictureY = 100f;  // Y-coordinate
                    float pictureWidth = 400f;
                    float pictureHeight = 300f;

                    // Insert the picture frame onto the first slide
                    pres.Slides[0].Shapes.AddPictureFrame(
                        ShapeType.Rectangle,
                        pictureX,
                        pictureY,
                        pictureWidth,
                        pictureHeight,
                        img);
                }

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}