using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add video to the presentation from a file stream
            using (FileStream videoStream = new FileStream("sample.mp4", FileMode.Open, FileAccess.Read))
            {
                Aspose.Slides.IVideo video = presentation.Videos.AddVideo(videoStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
                // Add a video frame to the slide and associate the embedded video
                Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 350, video);
                // Configure playback options
                videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
                videoFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;
            }

            // Save the presentation before exiting
            presentation.Save("VideoPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}