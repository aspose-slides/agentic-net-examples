using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // ---------- Add picture with hyperlink ----------
            // Load image bytes (replace with actual image path)
            byte[] pictureData = File.ReadAllBytes("image.png");
            IPPImage pictureImage = presentation.Images.AddImage(pictureData);
            IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 200, 150, pictureImage);
            // Assign external hyperlink to the picture
            pictureFrame.HyperlinkClick = new Hyperlink("https://www.example.com/picture");
            pictureFrame.HyperlinkClick.Tooltip = "Picture Link";

            // ---------- Add audio with hyperlink ----------
            // Load audio bytes (replace with actual audio path)
            byte[] audioData = File.ReadAllBytes("audio.mp3");
            IAudio audio = presentation.Audios.AddAudio(audioData);
            IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(300, 50, 100, 100, audio);
            // Assign external hyperlink to the audio
            audioFrame.HyperlinkClick = new Hyperlink("https://www.example.com/audio");
            audioFrame.HyperlinkClick.Tooltip = "Audio Link";

            // ---------- Add video with hyperlink ----------
            // Load video bytes (replace with actual video path)
            byte[] videoData = File.ReadAllBytes("video.mp4");
            IVideo video = presentation.Videos.AddVideo(videoData);
            IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(300, 200, 200, 150, video);
            // Assign external hyperlink to the video
            videoFrame.HyperlinkClick = new Hyperlink("https://www.example.com/video");
            videoFrame.HyperlinkClick.Tooltip = "Video Link";

            // Save the presentation
            presentation.Save("MediaHyperlinks.pptx", SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}