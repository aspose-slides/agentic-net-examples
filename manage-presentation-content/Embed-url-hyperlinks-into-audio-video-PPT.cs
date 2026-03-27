using System;
using System.IO;
using Aspose.Slides.Export;

namespace MediaHyperlinkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputAudioPath = "audio.wav";
            string inputVideoPath = "video.mp4";
            string outputPath = "output.pptx";
            string audioUrl = "https://example.com/audio";
            string videoUrl = "https://example.com/video";

            if (!File.Exists(inputAudioPath))
            {
                Console.WriteLine("Audio file not found: " + inputAudioPath);
                return;
            }

            if (!File.Exists(inputVideoPath))
            {
                Console.WriteLine("Video file not found: " + inputVideoPath);
                return;
            }

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add audio frame with hyperlink
            FileStream audioStream = new FileStream(inputAudioPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            Aspose.Slides.IAudio audio = pres.Audios.AddAudio(audioStream, Aspose.Slides.LoadingStreamBehavior.ReadStreamAndRelease);
            audioStream.Close();
            Aspose.Slides.IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10f, 10f, 100f, 100f, audio);
            audioFrame.HyperlinkClick = new Aspose.Slides.Hyperlink(audioUrl);
            audioFrame.HyperlinkClick.Tooltip = "Play audio";

            // Add video frame with hyperlink
            byte[] videoBytes = File.ReadAllBytes(inputVideoPath);
            Aspose.Slides.IVideo video = pres.Videos.AddVideo(videoBytes);
            Aspose.Slides.IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(150f, 10f, 300f, 200f, video);
            videoFrame.HyperlinkClick = new Aspose.Slides.Hyperlink(videoUrl);
            videoFrame.HyperlinkClick.Tooltip = "Play video";

            // Save presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}