using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace VideoFrameExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Open the video file as a stream
                FileStream videoStream = new FileStream("sample_video.mp4", FileMode.Open, FileAccess.Read, FileShare.Read);

                // Add the video to the presentation's video collection
                Aspose.Slides.IVideo video = presentation.Videos.AddVideo(videoStream, Aspose.Slides.LoadingStreamBehavior.ReadStreamAndRelease);
                videoStream.Close();

                // Add a video frame to the slide and associate the embedded video
                Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 350, video);
                videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
                videoFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

                // Save the presentation
                presentation.Save("VideoFrameOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}