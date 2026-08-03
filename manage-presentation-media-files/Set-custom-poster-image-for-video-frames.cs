// -----------------------------------------------------------------------------
// Example: Set custom poster image for video frames using C#
//
// Description:
// Shows how to load a video file and a separate poster image from disk, add the
// video to a new presentation, create a video frame on the first slide, assign
// the custom poster image to the video frame, and save the presentation as PPTX.
// The example also includes basic file existence checks and error handling
// for unsupported formats.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Video, Poster Image, VideoFrame,
// File I/O, Presentation Automation, Office Automation
//
// Use Cases:
// - Add videos with custom thumbnail images to PowerPoint slides programmatically.
// - Build .NET utilities that prepare presentations with specific media assets.
// - Automate validation of video and poster resources before generating PPTX files.
// - Integrate video handling into larger presentation processing workflows.
// -----------------------------------------------------------------------------
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
