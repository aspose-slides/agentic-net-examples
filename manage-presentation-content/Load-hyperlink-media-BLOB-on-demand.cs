using System;
using System.IO;
using System.Net;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputVideoPath = "largeVideo.mp4";
        string outputPath = "outputPresentation.pptx";

        // Verify that the video file exists
        if (!File.Exists(inputVideoPath))
        {
            Console.WriteLine("Video file not found.");
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            // Create a new presentation
            presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add large video as a BLOB using KeepLocked behavior
            FileStream videoStream = new FileStream(inputVideoPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            Aspose.Slides.IVideo video = presentation.Videos.AddVideo(videoStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
            videoStream.Close();

            // Insert video frame onto the slide
            Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 350, video);
            videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
            videoFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

            // Add a text box to host the external hyperlink
            Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 10, 10, 200, 50);
            shape.AddTextFrame("Click here");
            Aspose.Slides.IPortion portion = shape.TextFrame.Paragraphs[0].Portions[0];
            Aspose.Slides.IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;

            // Set external hyperlink using HyperlinkManager
            try
            {
                hyperlinkManager.SetExternalHyperlinkClick("https://www.example.com");
            }
            catch (WebException)
            {
                // Handle external URL exception
                Console.WriteLine("Failed to set external hyperlink.");
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        finally
        {
            if (presentation != null)
                presentation.Dispose();
        }
    }
}