using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Open the video file stream
            FileStream videoStream = new FileStream("sample.mp4", FileMode.Open, FileAccess.Read, FileShare.Read);

            // Add the video to the presentation
            Aspose.Slides.IVideo video = presentation.Videos.AddVideo(videoStream, Aspose.Slides.LoadingStreamBehavior.ReadStreamAndRelease);

            // Close the video stream
            videoStream.Close();

            // Add a video frame to the slide
            Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 350, video);

            // Set playback mode and volume
            videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
            videoFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

            // Save the presentation
            presentation.Save("VideoPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}