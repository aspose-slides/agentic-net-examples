using System;
using System.IO;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // URL of the image to download
        string imageUrl = "https://example.com/image.jpg";

        // Download image data as byte array
        byte[] imageBytes;
        using (HttpClient client = new HttpClient())
        {
            System.Threading.Tasks.Task<byte[]> downloadTask = client.GetByteArrayAsync(imageUrl);
            downloadTask.Wait();
            imageBytes = downloadTask.Result;
        }

        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a heading textbox
            Aspose.Slides.IAutoShape headingShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 20, 600, 50);
            headingShape.TextFrame.Text = "Image from Web";

            // Add the downloaded image to the presentation
            Aspose.Slides.IPPImage img = pres.Images.AddImage(imageBytes);

            // Insert the image onto the slide
            slide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 300, img);

            // Save the presentation
            pres.Save("WebImagePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}