using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string videoPath = "sample.mp4";
        string outputPath = "output.pptx";
        string hyperlinkUrl = "https://www.example.com/video";

        if (!File.Exists(videoPath))
        {
            Console.WriteLine("Video file does not exist: " + videoPath);
            return;
        }

        try
        {
            using (Presentation pres = new Presentation())
            {
                ISlide slide = pres.Slides[0];
                IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(10, 10, 400, 300, videoPath);
                videoFrame.PlayMode = VideoPlayModePreset.Auto;
                videoFrame.HyperlinkClick = new Hyperlink(hyperlinkUrl);
                videoFrame.HyperlinkClick.Tooltip = "Open video link";

                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}