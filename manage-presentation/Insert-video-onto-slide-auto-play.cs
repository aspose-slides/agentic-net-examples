using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace VideoOnClickExample
{
    class Program
    {
        static void Main()
        {
            // Input video file path
            string videoPath = "sample.mp4";
            // Output presentation file path
            string outputPath = "VideoOnClick_out.pptx";

            // Verify that the video file exists
            if (!File.Exists(videoPath))
            {
                Console.WriteLine("Video file not found: " + videoPath);
                return;
            }

            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Add the video to the presentation's video collection
                FileStream videoStream = new FileStream(videoPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                IVideo video = pres.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
                videoStream.Close();

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Insert a video frame onto the slide
                IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 250, video);

                // Configure the video to play when the frame is clicked
                videoFrame.PlayMode = VideoPlayModePreset.OnClick;

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);

                // Dispose the presentation
                pres.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}