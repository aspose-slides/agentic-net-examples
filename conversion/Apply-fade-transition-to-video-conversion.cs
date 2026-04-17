using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesVideoConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input video file path
            string inputVideoPath = "sample.mp4";
            // Output presentation file path
            string outputPresentationPath = "VideoPresentation_out.pptx";
            // Directory to store rendered frames
            string outputFramesDir = "RenderedFrames";

            // Verify that the input video file exists
            if (!File.Exists(inputVideoPath))
            {
                Console.WriteLine("Input video file not found: " + inputVideoPath);
                return;
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add the video to the presentation from a file stream
            FileStream videoStream = new FileStream(inputVideoPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            Aspose.Slides.IVideo video = presentation.Videos.AddVideo(videoStream, Aspose.Slides.LoadingStreamBehavior.ReadStreamAndRelease);
            videoStream.Close();

            // Add a video frame to the slide
            Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 350, video);
            videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
            videoFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

            // Apply a Fade transition to the slide
            presentation.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFramesDir);

            // Generate animation frames from the presentation
            using (Aspose.Slides.Export.PresentationAnimationsGenerator animationsGenerator = new Aspose.Slides.Export.PresentationAnimationsGenerator(presentation))
            {
                // Set frames per second for rendering
                using (Aspose.Slides.Export.PresentationPlayer player = new Aspose.Slides.Export.PresentationPlayer(animationsGenerator, 30))
                {
                    player.FrameTick += (sender, eventArgs) =>
                    {
                        string frameFile = Path.Combine(outputFramesDir, $"frame_{sender.FrameIndex}.png");
                        // Save each frame as PNG
                        eventArgs.GetFrame().Save(frameFile, Aspose.Slides.ImageFormat.Png);
                    };

                    // Run the animation generation for all slides
                    animationsGenerator.Run(presentation.Slides);
                }
            }

            // Save the presentation (handle unsupported format)
            try
            {
                presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested save format is not supported.");
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}