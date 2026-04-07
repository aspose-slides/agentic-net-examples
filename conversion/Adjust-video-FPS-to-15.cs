using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input video file path
        string videoPath = "sample.mp4";
        // Output presentation path
        string outputPath = "output.pptx";

        // Verify that the video file exists
        if (!File.Exists(videoPath))
        {
            Console.WriteLine("Video file not found: " + videoPath);
            return;
        }

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Embed the video into the presentation
            Aspose.Slides.IVideo video = presentation.Videos.AddVideo(File.ReadAllBytes(videoPath));

            // Add a video frame to the slide (using the add-video-frame rule)
            Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 150, video);
            videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
            videoFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

            // NOTE: Aspose.Slides does not provide a direct API to change the FPS of an embedded video.
            // To achieve a lower FPS (e.g., 15 FPS) and reduce file size, re-encode the source video
            // with the desired frame rate before embedding it.

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            // Comment: The provided video format is not supported by Aspose.Slides.
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., I/O errors, library errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}