// -----------------------------------------------------------------------------
// Example: Insert video frame slide with autoplay using C#
//
// Description:
// Demonstrates how to insert a video frame slide with autoplay using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Video, Frame, Slide, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insert video frame slide with autoplay.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertVideoFrameWithAutoplay
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the video file to embed
            string videoPath = "sample_video.mp4";

            // Output presentation file
            string outputPath = "VideoPresentation.pptx";

            // Verify that the video file exists
            if (!File.Exists(videoPath))
            {
                Console.WriteLine($"Video file not found: {videoPath}");
                return;
            }

            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Add a new empty slide based on the layout of the first slide
                    ISlide newSlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

                    // Add the video to the presentation's video collection using a FileStream
                    using (FileStream videoStream = new FileStream(videoPath, FileMode.Open, FileAccess.Read))
                    {
                        IVideo video = pres.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
                        // Insert a video frame onto the new slide
                        IVideoFrame videoFrame = newSlide.Shapes.AddVideoFrame(50, 150, 400, 300, video);
                        // Set the video to play automatically
                        videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
                    }

                    // Save the presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine($"Presentation saved successfully to {outputPath}");
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Handle unsupported PPTX format errors
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                // Handle unsupported PPT format errors
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors, web errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
