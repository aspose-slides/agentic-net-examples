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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add video to the presentation's video collection
            Aspose.Slides.IVideo video = presentation.Videos.AddVideo(File.ReadAllBytes("sample.mp4"));

            // Create a video frame on the slide
            Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50f, 150f, 300f, 350f, video);

            // Set video playback properties
            videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
            videoFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

            // Save the presentation
            presentation.Save("VideoFrame_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}