using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceVideoInPptx
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output file paths
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";
                string newVideoPath = "newVideo.mp4";

                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Find the first video frame on the slide
                IVideoFrame videoFrame = null;
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is IVideoFrame)
                    {
                        videoFrame = (IVideoFrame)shape;
                        break;
                    }
                }

                if (videoFrame != null)
                {
                    // Add the new video to the presentation's video collection
                    FileStream videoStream = new FileStream(newVideoPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    IVideo newVideo = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
                    videoStream.Close();

                    // Replace the embedded video while preserving geometry and layout
                    videoFrame.EmbeddedVideo = newVideo;
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}