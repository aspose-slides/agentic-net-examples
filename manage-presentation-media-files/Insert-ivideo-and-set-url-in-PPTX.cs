using System;
using System.IO;
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace VideoInsertionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Define the video URL
                string videoUrl = "https://example.com/samplevideo.mp4";

                // Download video bytes
                WebClient webClient = new WebClient();
                byte[] videoData = webClient.DownloadData(videoUrl);

                // Add video to the presentation's video collection
                IVideo video = presentation.Videos.AddVideo(videoData);

                // Add a video frame to the slide using the embedded video
                IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 350, video);

                // Set a hyperlink on the video frame to the original URL
                videoFrame.HyperlinkClick = new Hyperlink(videoUrl);
                videoFrame.HyperlinkClick.Tooltip = "Open video in browser";

                // Save the presentation
                presentation.Save("VideoPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}