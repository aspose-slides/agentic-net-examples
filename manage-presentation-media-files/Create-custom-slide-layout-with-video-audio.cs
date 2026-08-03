// -----------------------------------------------------------------------------
// Example: Create custom slide layout with video and audio using C#
//
// Description:
// Demonstrates how to create a custom slide layout that contains video and
// audio placeholders, embed media files, and add corresponding video and audio
// frames to a slide using Aspose.Slides for .NET. The example shows the required
// presentation-processing steps for PowerPoint files and produces a PPTX file
// with embedded media in a standalone console application. Developers can use
// this pattern to automate PPTX workflows, validate results, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Custom Slide Layout, Video,
// Audio, Media Embedding, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of custom slide layouts with embedded video and audio.
// - Build C# tools for PowerPoint media handling and presentation processing.
// - Generate or transform PPTX files with media content in .NET applications.
// - Validate media embedding workflows before publishing or integration.
// -----------------------------------------------------------------------------
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
            using (FileStream videoStream = new FileStream(videoPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                IVideo video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
                // Add video frame to the slide
                IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50f, 150f, 300f, 200f, video);
                videoFrame.PlayMode = VideoPlayModePreset.Auto;
                videoFrame.Volume = AudioVolumeMode.Loud;
            }

            // Embed audio into the presentation
            using (FileStream audioStream = new FileStream(audioPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                IAudio audio = presentation.Audios.AddAudio(audioStream);
                // Add audio frame to the slide
                IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(400f, 150f, 300f, 200f, audio);
                audioFrame.PlayMode = AudioPlayModePreset.Auto;
                audioFrame.Volume = AudioVolumeMode.Loud;
            }

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
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
