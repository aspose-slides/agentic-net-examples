using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Load the presentation from file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("Video.pptx"))
        {
            // Loop through each slide
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                // Loop through each shape on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    // Identify video frames
                    if (shape is Aspose.Slides.VideoFrame)
                    {
                        Aspose.Slides.IVideoFrame videoFrame = (Aspose.Slides.IVideoFrame)shape;
                        Aspose.Slides.IVideo video = videoFrame.EmbeddedVideo;
                        // Get file extension from content type
                        string contentType = video.ContentType;
                        int slashPos = contentType.LastIndexOf('/');
                        string extension = contentType.Substring(slashPos + 1);
                        // Export video using stream to avoid loading whole data into memory
                        using (Stream videoStream = video.GetStream())
                        {
                            using (FileStream fileStream = new FileStream($"ExtractedVideo_{slideIndex}_{shapeIndex}." + extension, FileMode.Create, FileAccess.Write))
                            {
                                byte[] buffer = new byte[8192];
                                int bytesRead;
                                while ((bytesRead = videoStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    fileStream.Write(buffer, 0, bytesRead);
                                }
                            }
                        }
                    }
                }
            }
            // Save the presentation (required by rule)
            presentation.Save("Video_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}