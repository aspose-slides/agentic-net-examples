using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input video file and output paths
            string inputVideoPath = "sample.mp4";
            string outputPresentationPath = "output.pptx";
            string extractedVideosDir = "extracted_videos";

            // Create a new presentation and get the first slide
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add video to the presentation
            System.IO.FileStream videoStream = new System.IO.FileStream(inputVideoPath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
            Aspose.Slides.IVideo video = presentation.Videos.AddVideo(videoStream, Aspose.Slides.LoadingStreamBehavior.ReadStreamAndRelease);
            videoStream.Close();

            // Insert video frame onto the slide and set properties
            Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 350, video);
            videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
            videoFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

            // Save the presentation
            presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Extract embedded videos from the presentation
            System.IO.Directory.CreateDirectory(extractedVideosDir);
            int videoIndex = 0;
            foreach (Aspose.Slides.ISlide s in presentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in s.Shapes)
                {
                    if (shape is Aspose.Slides.VideoFrame)
                    {
                        Aspose.Slides.IVideoFrame vf = (Aspose.Slides.IVideoFrame)shape;
                        string contentType = vf.EmbeddedVideo.ContentType;
                        int slashPos = contentType.LastIndexOf('/');
                        string extension = contentType.Substring(slashPos + 1);
                        byte[] data = vf.EmbeddedVideo.BinaryData;
                        string outPath = System.IO.Path.Combine(extractedVideosDir, $"video_{videoIndex}.{extension}");
                        using (System.IO.FileStream fs = new System.IO.FileStream(outPath, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.Read))
                        {
                            fs.Write(data, 0, data.Length);
                        }
                        videoIndex++;
                    }
                }
            }

            // Clean up
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}