// -----------------------------------------------------------------------------
// Example: Apply Fade‑In Animation to Video Frame in PowerPoint using C#
// 
// Description:
// This console application demonstrates how to insert a video frame into a
// PPTX file, configure its playback settings, apply a fade‑in animation effect,
// and save the modified presentation. It uses Aspose.Slides for .NET to
// manipulate PowerPoint files programmatically.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, video frame, fade‑in animation, automation
// 
// Use Cases:
// - Automate adding instructional videos with entrance animations to slide decks.
// - Generate presentations with consistent video playback settings for e‑learning.
// - Integrate video‑enhanced slides into a CI/CD pipeline for report generation.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesVideoFadeIn
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input video file path
            string videoPath = "sample_video.mp4";
            // Output presentation path
            string outputPath = "VideoFadeInPresentation.pptx";

            // Verify input video exists
            if (!File.Exists(videoPath))
            {
                Console.WriteLine("Error: Video file not found at " + videoPath);
                return;
            }

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add video frame to the slide
                Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 150, videoPath);
                videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
                videoFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

                // Apply fade‑in animation effect to the video frame
                slide.Timeline.MainSequence.AddEffect(
                    videoFrame,
                    Aspose.Slides.Animation.EffectType.Fade,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully to " + outputPath);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
