using System;
using System.IO;
using Aspose.Slides.Export;

namespace EmbedVideoDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string videoPath = "sample.mp4";

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    using (FileStream videoStream = new FileStream(videoPath, FileMode.Open, FileAccess.Read))
                    {
                        Aspose.Slides.IVideo video = presentation.Videos.AddVideo(videoStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
                        Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 350, video);
                        videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
                        videoFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;
                    }

                    presentation.Save("VideoPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}