using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input file paths
        string audioPath = "sampleaudio.wav";
        string videoPath = "samplevideo.mp4";
        string outputPath = "CustomLayoutMedia.pptx";

        // Verify input files exist
        if (!File.Exists(audioPath))
        {
            Console.WriteLine("Audio file not found: " + audioPath);
            return;
        }

        if (!File.Exists(videoPath))
        {
            Console.WriteLine("Video file not found: " + videoPath);
            return;
        }

        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get a blank layout slide to customize
            ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

            // Add a video placeholder to the layout
            IAutoShape videoPlaceholder = layout.PlaceholderManager.AddMediaPlaceholder(50f, 150f, 300f, 200f);

            // Add an audio placeholder to the layout
            IAutoShape audioPlaceholder = layout.PlaceholderManager.AddMediaPlaceholder(400f, 150f, 300f, 200f);

            // Add a new slide based on the custom layout
            ISlide slide = presentation.Slides.AddEmptySlide(layout);

            // Embed video into the presentation
            FileStream videoStream = new FileStream(videoPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            IVideo video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
            videoStream.Close();

            // Add video frame to the slide
            IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50f, 150f, 300f, 200f, video);
            videoFrame.PlayMode = VideoPlayModePreset.Auto;
            videoFrame.Volume = AudioVolumeMode.Loud;

            // Embed audio into the presentation
            FileStream audioStream = new FileStream(audioPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            IAudio audio = presentation.Audios.AddAudio(audioStream);
            audioStream.Close();

            // Add audio frame to the slide
            IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(400f, 150f, 300f, 200f, audio);
            audioFrame.PlayMode = AudioPlayModePreset.Auto;
            audioFrame.Volume = AudioVolumeMode.Loud;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., web service errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}