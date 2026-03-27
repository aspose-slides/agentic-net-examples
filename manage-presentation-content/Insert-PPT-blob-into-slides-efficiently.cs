using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the large binary BLOB (video file)
        const string videoPath = "largeVideo.avi";
        // Path where the resulting presentation will be saved
        const string outputPath = "PresentationWithLargeVideo.pptx";

        // Verify that the video file exists before proceeding
        if (!File.Exists(videoPath))
        {
            Console.WriteLine("Video file not found: " + videoPath);
            return;
        }

        // Create a new presentation (contains one empty slide by default)
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Open the video file as a stream
        FileStream videoStream = new FileStream(videoPath, FileMode.Open, FileAccess.Read);

        // Add the video to the presentation as a BLOB using KeepLocked behavior to avoid loading it fully into memory
        Aspose.Slides.IVideo video = pres.Videos.AddVideo(videoStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

        // Insert a video frame on the first slide referencing the added video
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Save the presentation to disk
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        pres.Dispose();
        videoStream.Dispose();
    }
}