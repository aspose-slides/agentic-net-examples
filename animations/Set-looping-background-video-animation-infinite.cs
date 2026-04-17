using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetLoopingBackgroundVideo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the video file (can be changed or passed via args)
            string videoPath = "background.mp4";

            // Check if the video file exists
            if (!File.Exists(videoPath))
            {
                Console.WriteLine("Video file not found: " + videoPath);
                return;
            }

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add the video to the presentation's video collection
                FileStream videoStream = new FileStream(videoPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                IVideo video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
                videoStream.Close();

                // Add a video frame to the slide
                IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 720, 540, video);

                // Set the video to play automatically and loop infinitely
                videoFrame.PlayMode = VideoPlayModePreset.Auto;
                videoFrame.PlayLoopMode = true;

                // Save the presentation
                presentation.Save("LoopingBackgroundVideo.pptx", SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}