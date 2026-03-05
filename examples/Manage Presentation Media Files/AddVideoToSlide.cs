using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a video frame by specifying the video file path
        Aspose.Slides.IVideoFrame videoFramePath = slide.Shapes.AddVideoFrame(50, 150, 300, 150, "sampleVideo.mp4");
        videoFramePath.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
        videoFramePath.Volume = Aspose.Slides.AudioVolumeMode.Loud;

        // Add an embedded video frame
        System.IO.FileStream videoStream = new System.IO.FileStream("embeddedVideo.mp4", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
        Aspose.Slides.IVideo embeddedVideo = presentation.Videos.AddVideo(videoStream, Aspose.Slides.LoadingStreamBehavior.ReadStreamAndRelease);
        videoStream.Close();

        Aspose.Slides.IVideoFrame videoFrameEmbedded = slide.Shapes.AddVideoFrame(50, 350, 300, 150, embeddedVideo);
        videoFrameEmbedded.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
        videoFrameEmbedded.Volume = Aspose.Slides.AudioVolumeMode.Loud;

        // Save the presentation
        presentation.Save("AddVideoExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}