using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add video to the presentation from a file stream
                IVideo video;
                using (FileStream videoStream = new FileStream("sample.mp4", FileMode.Open, FileAccess.Read))
                {
                    video = pres.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
                }

                // Add a video frame to the slide and associate the embedded video
                IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50f, 150f, 300f, 350f, video);
                videoFrame.PlayMode = VideoPlayModePreset.Auto;
                videoFrame.Volume = AudioVolumeMode.Loud;

                // Save the presentation
                pres.Save("EmbeddedVideo.pptx", SaveFormat.Pptx);

                // Clean up
                pres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}