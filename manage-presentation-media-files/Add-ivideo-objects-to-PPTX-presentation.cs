using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddVideoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input video and output presentation
            string inputVideoPath = "sample.mp4";
            string outputPresentationPath = "VideoFrame_out.pptx";

            // Ensure resources are released properly
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Open the video file stream
                FileStream videoStream = new FileStream(inputVideoPath, FileMode.Open, FileAccess.Read, FileShare.Read);

                // Add the video to the presentation's video collection
                IVideo video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);

                // Close the video stream as per the rule
                videoStream.Close();

                // Add a video frame to the slide using the embedded video
                IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 350, video);

                // Set playback mode and volume
                videoFrame.PlayMode = VideoPlayModePreset.Auto;
                videoFrame.Volume = AudioVolumeMode.Loud;

                // Save the presentation
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}