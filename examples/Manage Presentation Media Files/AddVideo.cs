using System;
using System.IO;
using Aspose.Slides;

namespace VideoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a video to the presentation from a file stream
                using (FileStream videoStream = new FileStream("sample.mp4", FileMode.Open))
                {
                    Aspose.Slides.IVideo video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);

                    // Add a video frame to the slide using the IVideo object
                    Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50f, 150f, 300f, 350f, video);

                    // Set the link path for the video frame (optional, can be a file name or URL)
                    videoFrame.LinkPathLong = "sample.mp4";
                }

                // Save the presentation in PPTX format
                presentation.Save("VideoPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}