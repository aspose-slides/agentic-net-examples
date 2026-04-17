using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace VideoFrameExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string videoPath = "sample.mp4";
            string outputPath = "output.pptx";

            // Check if the video file exists
            if (!File.Exists(videoPath))
            {
                Console.WriteLine("Video file not found: " + videoPath);
                return;
            }

            try
            {
                // Create a new presentation
                var presentation = new Presentation();

                // Ensure the presentation has at least three slides
                while (presentation.Slides.Count < 3)
                {
                    presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                }

                // Get the third slide (index 2)
                var slide = presentation.Slides[2];

                // Add a video frame to the third slide
                var videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 150, videoPath);

                // Set autoplay and loop playback options
                videoFrame.PlayMode = VideoPlayModePreset.Auto;
                videoFrame.PlayLoopMode = true;

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
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}