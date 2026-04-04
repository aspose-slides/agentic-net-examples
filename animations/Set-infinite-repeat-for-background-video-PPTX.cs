using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        string inputVideoPath = "video.mp4";
        string outputPath = "output.pptx";

        // Check if the input video file exists
        if (!File.Exists(inputVideoPath))
        {
            Console.WriteLine("Input video file does not exist.");
            return;
        }

        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a video frame to the first slide
            ISlide slide = pres.Slides[0];
            IVideo video = pres.Videos.AddVideo(File.ReadAllBytes(inputVideoPath));
            IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 720, 540, video);
            videoFrame.PlayLoopMode = true; // Loop the video playback

            // Add an animation effect to the video frame
            ISequence sequence = pres.Slides[0].Timeline.MainSequence;
            IEffect effect = sequence.AddEffect(videoFrame, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

            // Set the animation to repeat infinitely (until end of slide)
            effect.Timing.RepeatUntilEndSlide = true;
            effect.Timing.RepeatUntilNextClick = true;

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}