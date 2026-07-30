// -----------------------------------------------------------------------------
// Example: Add video frame third slide autoplay loop using C#
//
// Description:
// Demonstrates how to add a video frame to the third slide of a presentation,
// configure it for autoplay and loop playback, and save the result as a PPTX
// file using Aspose.Slides for .NET. The example includes validation of the
// source video file, ensures the presentation contains at least three slides,
// and shows the necessary presentation‑processing steps in a standalone console
// application.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Video, Frame, Third Slide, 
// Autoplay, Loop, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a video frame with autoplay and loop to the third slide.
// - Build C# utilities for PowerPoint media handling and presentation automation.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate media integration workflows before publishing presentations.
// -----------------------------------------------------------------------------
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
