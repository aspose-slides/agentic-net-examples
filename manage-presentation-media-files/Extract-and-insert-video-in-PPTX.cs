using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace VideoExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                var inputPath = "input.pptx";
                var outputPath = "output.pptx";
                var videoFilePath = "sample.mp4";

                // Load existing presentation
                using (var presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Insert a video into the first slide
                    using (var videoStream = new FileStream(videoFilePath, FileMode.Open, FileAccess.Read))
                    {
                        var addedVideo = presentation.Videos.AddVideo(videoStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
                        var firstSlide = presentation.Slides[0];
                        firstSlide.Shapes.AddVideoFrame(50, 150, 300, 350, addedVideo);
                    }

                    // Extract all embedded videos
                    var buffer = new byte[8 * 1024];
                    for (var index = 0; index < presentation.Videos.Count; index++)
                    {
                        var video = presentation.Videos[index];
                        var contentType = video.ContentType; // e.g., "video/mp4"
                        var extension = contentType.Substring(contentType.LastIndexOf('/') + 1);
                        var outputVideoPath = $"extracted_video_{index}.{extension}";

                        using (var videoStream = video.GetStream())
                        using (var fileStream = new FileStream(outputVideoPath, FileMode.Create, FileAccess.Write))
                        {
                            int bytesRead;
                            while ((bytesRead = videoStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                fileStream.Write(buffer, 0, bytesRead);
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}