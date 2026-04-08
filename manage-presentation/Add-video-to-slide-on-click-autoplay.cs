using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace VideoDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input video and output presentation
            string inputVideoPath = "sample_video.mp4";
            string outputPresentationPath = "VideoPresentation.pptx";

            // Verify that the video file exists
            if (!File.Exists(inputVideoPath))
            {
                Console.WriteLine("Video file not found: " + inputVideoPath);
                return;
            }

            // Create a new presentation
            Presentation presentation = new Presentation();

            try
            {
                // Get the first slide (index 0)
                ISlide slide = presentation.Slides[0];

                // Add a video frame to the slide using the provided rule
                IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 150, inputVideoPath);
                // Configure the video to play on click
                videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.OnClick;
                // Optionally set volume
                videoFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

                // Save the presentation
                presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is disposed
                presentation.Dispose();
            }
        }
    }
}