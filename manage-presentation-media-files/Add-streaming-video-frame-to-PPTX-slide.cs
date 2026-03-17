using System;
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyPresentationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Define YouTube video ID and construct embed URL
                string videoId = "Tj75Arhq5ho";
                string videoUrl = "https://www.youtube.com/embed/" + videoId;

                // Add video frame that streams from the web URL
                Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
                videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;

                // Load thumbnail image from the web and set it as the video frame picture
                using (WebClient client = new WebClient())
                {
                    string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
                    byte[] imageData = client.DownloadData(thumbnailUri);
                    videoFrame.PictureFormat.Picture.Image = presentation.Images.AddImage(imageData);
                }

                // Save the presentation
                presentation.Save("VideoFromWeb_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}