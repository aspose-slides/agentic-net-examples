using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add video to the presentation from a file stream
        using (FileStream videoStream = new FileStream("sample.mp4", FileMode.Open, FileAccess.Read))
        {
            IVideo video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
            // Add a video frame to the slide using the IVideo object
            IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50f, 150f, 300f, 350f, video);
        }

        // Save the presentation
        presentation.Save("VideoPresentation_out.pptx", SaveFormat.Pptx);
    }
}