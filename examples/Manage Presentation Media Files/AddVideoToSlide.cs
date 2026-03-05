using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a video frame that embeds a local video file
        Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 150, "sample_video.mp4");

        // Set playback mode and volume
        videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
        videoFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

        // Save the presentation in PPTX format
        pres.Save("VideoPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        pres.Dispose();
    }
}