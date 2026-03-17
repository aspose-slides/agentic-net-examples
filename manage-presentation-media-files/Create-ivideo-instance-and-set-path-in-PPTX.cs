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
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Path to the video file
                string videoPath = "sample_video.mp4";

                // Open video file stream
                FileStream videoStream = new FileStream(videoPath, FileMode.Open, FileAccess.Read, FileShare.Read);

                // Add video to the presentation
                Aspose.Slides.IVideo video = presentation.Videos.AddVideo(videoStream, Aspose.Slides.LoadingStreamBehavior.ReadStreamAndRelease);

                // Close the stream as it's no longer needed
                videoStream.Close();

                // Add video frame to the slide
                Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 350, video);

                // Set playback mode and volume
                videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
                videoFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

                // Save the presentation
                presentation.Save("VideoPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose presentation
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}