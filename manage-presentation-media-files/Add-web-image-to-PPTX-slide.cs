using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var httpClient = new HttpClient();
            var imageUrl = "https://example.com/image.jpg";
            var imageBytes = httpClient.GetByteArrayAsync(imageUrl).Result;

            using (var presentation = new Aspose.Slides.Presentation())
            {
                var image = presentation.Images.AddImage(imageBytes);
                var slide = presentation.Slides[0];
                slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300, image);
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}