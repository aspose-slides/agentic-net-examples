using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string videoPath = "sample.mp4";
        string outputPath = "VideoPlaceholderMaster.pptx";

        if (!File.Exists(videoPath))
        {
            Console.WriteLine("Video file does not exist: " + videoPath);
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

            System.IO.FileStream videoStream = new System.IO.FileStream(videoPath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
            Aspose.Slides.IVideo video = presentation.Videos.AddVideo(videoStream, Aspose.Slides.LoadingStreamBehavior.ReadStreamAndRelease);
            videoStream.Close();

            Aspose.Slides.IVideoFrame videoFrame = masterSlide.Shapes.AddVideoFrame(50, 150, 300, 350, video);
            videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
            videoFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}