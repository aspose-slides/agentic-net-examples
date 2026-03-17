using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace EmbedMediaHyperlinks
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                var presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                var slide = presentation.Slides[0];

                // Add an audio file and embed it into the slide
                var audioBytes = File.ReadAllBytes("audio.mp3");
                var audio = presentation.Audios.AddAudio(audioBytes);
                var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);
                audioFrame.HyperlinkClick = new Aspose.Slides.Hyperlink("https://www.example.com/audio");
                audioFrame.HyperlinkClick.Tooltip = "Play audio";

                // Add a video file and embed it into the slide
                var videoBytes = File.ReadAllBytes("video.mp4");
                var video = presentation.Videos.AddVideo(videoBytes);
                var videoFrame = slide.Shapes.AddVideoFrame(150, 10, 300, 200, video);
                videoFrame.HyperlinkClick = new Aspose.Slides.Hyperlink("https://www.example.com/video");
                videoFrame.HyperlinkClick.Tooltip = "Play video";

                // Save the presentation
                presentation.Save("MediaWithHyperlinks.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}