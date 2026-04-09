using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for video, poster image and output presentation
        string videoPath = "sample.mp4";
        string posterPath = "poster.jpg";
        string outputPath = "output.pptx";

        // Verify that the video file exists
        if (!File.Exists(videoPath))
        {
            Console.WriteLine("Video file not found.");
            return;
        }

        // Verify that the poster image file exists
        if (!File.Exists(posterPath))
        {
            Console.WriteLine("Poster image file not found.");
            return;
        }

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add the video to the presentation
        Aspose.Slides.IVideo video = null;
        try
        {
            byte[] videoData = File.ReadAllBytes(videoPath);
            video = pres.Videos.AddVideo(videoData);
        }
        catch (Exception ex)
        {
            // Handle unsupported video format
            Console.WriteLine("Video format not supported: " + ex.Message);
            pres.Dispose();
            return;
        }

        // Add a video frame to the first slide
        Aspose.Slides.IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(50, 150, 300, 200, video);
        videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;

        // Set a custom poster image for the video frame
        try
        {
            byte[] imageData = File.ReadAllBytes(posterPath);
            videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(imageData);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to set poster image: " + ex.Message);
        }

        // Save the presentation
        try
        {
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported save format
            Console.WriteLine("Saving format not supported: " + ex.Message);
        }

        // Dispose the presentation object
        pres.Dispose();
    }
}