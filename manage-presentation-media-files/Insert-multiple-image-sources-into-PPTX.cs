using System;
using System.IO;
using System.Net.Http;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (var presentation = new Aspose.Slides.Presentation())
            {
                var slide = presentation.Slides[0]; // ISlide

                // Add image from a local file
                var localImagePath = "localImage.jpg";
                using (var stream = new FileStream(localImagePath, FileMode.Open, FileAccess.Read))
                {
                    var img = presentation.Images.AddImage(stream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
                    slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300, img);
                }

                // Add image from a web URL
                var imageUrl = "https://example.com/image.png";
                using (var httpClient = new HttpClient())
                {
                    var imageData = httpClient.GetByteArrayAsync(imageUrl).Result;
                    var imgWeb = presentation.Images.AddImage(imageData);
                    slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 500, 50, 400, 300, imgWeb);
                }

                // Save the presentation
                presentation.Save("ResultPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
    }
}