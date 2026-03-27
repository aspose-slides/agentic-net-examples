using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string videoPath = "sample.mp4";
        string audioPath = "sample.wav";
        string htmlPath = "sample.html";
        string outputPath = "EmbeddedPresentation.pptx";

        if (!File.Exists(videoPath))
        {
            Console.WriteLine("Video file not found: " + videoPath);
            return;
        }
        if (!File.Exists(audioPath))
        {
            Console.WriteLine("Audio file not found: " + audioPath);
            return;
        }
        if (!File.Exists(htmlPath))
        {
            Console.WriteLine("HTML file not found: " + htmlPath);
            return;
        }

        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Embed video
        System.IO.FileStream videoStream = new System.IO.FileStream(videoPath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
        Aspose.Slides.IVideo video = presentation.Videos.AddVideo(videoStream, Aspose.Slides.LoadingStreamBehavior.ReadStreamAndRelease);
        videoStream.Close();
        Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 350, video);
        videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
        videoFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

        // Embed audio
        System.IO.FileStream audioStream = new System.IO.FileStream(audioPath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
        Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(400, 150, 100, 100, audioStream);
        audioStream.Close();
        audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
        audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

        // Add HTML content as new slides
        using (System.IO.FileStream htmlStream = new System.IO.FileStream(htmlPath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
        {
            presentation.Slides.AddFromHtml(htmlStream);
        }

        // Save presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}