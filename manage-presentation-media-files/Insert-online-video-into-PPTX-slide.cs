using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Define the online video URL (YouTube embed link)
            string videoUrl = "https://www.youtube.com/embed/Tj75Arhq5ho";

            // Add a video frame that references the online video
            Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);

            // Set the video to autoplay
            videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;

            // Save the presentation
            presentation.Save("OnlineVideoPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}