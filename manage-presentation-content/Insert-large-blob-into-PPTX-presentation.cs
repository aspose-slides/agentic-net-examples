using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input video and output presentation
        string inputVideoPath = "veryLargeVideo.avi";
        string outputPresentationPath = "presentationWithLargeVideo.pptx";

        // Verify that the input video file exists
        if (!File.Exists(inputVideoPath))
        {
            Console.WriteLine("Input video file not found: " + inputVideoPath);
            return;
        }

        // Create a new presentation
        Presentation pres = new Presentation();

        // Add the video to the presentation using KeepLocked behavior to handle large BLOB efficiently
        FileStream fileStream = new FileStream(inputVideoPath, FileMode.Open, FileAccess.Read, FileShare.Read);
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        fileStream.Close();

        // Add a video frame to the first slide
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Save the presentation
        pres.Save(outputPresentationPath, SaveFormat.Pptx);

        // Dispose the presentation object
        pres.Dispose();

        Console.WriteLine("Presentation saved to " + outputPresentationPath);
    }
}