using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input video file path
        string inputVideoPath = "sample.mp4";
        // Output presentation file
        string outputPath = "VideoWithLink.pptx";
        // External URL to launch video player
        string externalUrl = "https://example.com/player";

        // Verify that the input video file exists
        if (!File.Exists(inputVideoPath))
        {
            Console.WriteLine("Input video file does not exist: " + inputVideoPath);
            return;
        }

        try
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a video frame placeholder using the local video file
                Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 150, inputVideoPath);
                videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
                videoFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

                // Attach an external hyperlink that launches a video player when the video frame is clicked
                videoFrame.HyperlinkManager.SetExternalHyperlinkClick(externalUrl);

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, I/O errors, etc.)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}