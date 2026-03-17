using System;
using System.Net;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                string videoId = "Tj75Arhq5ho";
                Aspose.Slides.IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
                videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;

                using (WebClient client = new WebClient())
                {
                    string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
                    byte[] imageData = client.DownloadData(thumbnailUri);
                    Aspose.Slides.IPPImage thumbnail = pres.Images.AddImage(imageData);
                    videoFrame.PictureFormat.Picture.Image = thumbnail;
                }

                pres.Save("AddVideoFromYouTube_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}