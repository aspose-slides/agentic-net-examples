using System;
using System.Net;
using System.IO;
using Aspose.Slides.Export;

namespace InsertNetworkImage
{
    class Program
    {
        static void Main(string[] args)
        {
            // URL of the image to download
            string imageUrl = "https://example.com/image.jpg";
            // Output presentation file path
            string outputPath = "NetworkImagePresentation.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Stream to hold the downloaded image
            Stream imageStream = null;
            try
            {
                // Download image as a stream
                WebClient client = new WebClient();
                imageStream = client.OpenRead(imageUrl);

                // Add the image to the presentation's image collection
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

                // Insert the image into a picture frame on the first slide
                presentation.Slides[0].Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    50, 50, 400, 300,
                    image);

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (WebException webEx)
            {
                // Handle network-related errors
                Console.WriteLine("Failed to download image: " + webEx.Message);
            }
            catch (Exception ex)
            {
                // Handle other errors (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Clean up resources
                if (imageStream != null)
                {
                    imageStream.Dispose();
                }
                presentation.Dispose();
            }
        }
    }
}