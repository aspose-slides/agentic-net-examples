// -----------------------------------------------------------------------------
// Example: Add video to slide on click autoplay using C#
//
// Description:
// Demonstrates how to add a video to a slide that plays on click with autoplay
// using C# and Aspose.Slides for .NET. The example creates a new presentation,
// inserts a video frame, configures it to start playback on click, and saves the
// result as a PPTX file. This pattern can be used to automate PowerPoint
// workflows, embed media, or build presentation processing tools.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Video, Slide, Click, Autoplay,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding video to a slide with click-to-play behavior.
// - Build C# utilities for embedding media in PowerPoint presentations.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate media playback settings before publishing presentations.
// -----------------------------------------------------------------------------
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
