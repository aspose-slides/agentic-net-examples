using System;
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddWebVideoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // YouTube video identifier
            string videoId = "Tj75Arhq5ho";

            // Add a video frame that loads video from the web (YouTube embed URL)
            IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(
                10,                     // X position
                10,                     // Y position
                427,                    // Width
                240,                    // Height
                "https://www.youtube.com/embed/" + videoId); // Video URL

            // Set the video to play automatically
            videoFrame.PlayMode = VideoPlayModePreset.Auto;

            // Load and set a thumbnail image for the video frame
            using (WebClient client = new WebClient())
            {
                string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
                byte[] thumbnailData = client.DownloadData(thumbnailUri);
                IPPImage thumbnailImage = pres.Images.AddImage(thumbnailData);
                videoFrame.PictureFormat.Picture.Image = thumbnailImage;
            }

            // Save the presentation
            pres.Save("AddVideoFromWeb_out.pptx", SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
    }
}