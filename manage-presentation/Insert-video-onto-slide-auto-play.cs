// -----------------------------------------------------------------------------
// Example: Insert video onto slide auto play using C#
//
// Description:
// Demonstrates how to insert a video onto a slide with automatic playback using
// C# and Aspose.Slides for .NET. The example shows the required presentation‑
// processing steps for PowerPoint files and produces the requested output in a
// standalone console application. Developers can use this pattern to automate
// PPTX workflows, validate results, or integrate presentation logic into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Video, AutoPlay, Slide,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of video onto a slide with auto‑play behavior.
// - Build C# tools for PowerPoint presentation processing that include media.
// - Generate or transform PPTX files with embedded videos in .NET applications.
// - Validate presentation workflows involving video playback before publishing.
// -----------------------------------------------------------------------------
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

                // Configure the video to play automatically when the slide is shown
                videoFrame.PlayMode = VideoPlayModePreset.AutoPlay;

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
