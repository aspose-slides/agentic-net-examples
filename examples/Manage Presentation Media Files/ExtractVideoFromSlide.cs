using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from a PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("Video.pptx");

        // Iterate through all slides
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Iterate through all shapes on the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                // Check if the shape is a video frame
                if (shape is Aspose.Slides.IVideoFrame)
                {
                    Aspose.Slides.IVideoFrame videoFrame = (Aspose.Slides.IVideoFrame)shape;
                    Aspose.Slides.IVideo video = videoFrame.EmbeddedVideo;

                    // Determine file extension from the video's content type
                    string contentType = video.ContentType;
                    int slashPos = contentType.LastIndexOf('/');
                    string extension = contentType.Substring(slashPos + 1);

                    // Build output file name
                    string outputPath = $"ExtractedVideo_{slideIndex}_{shapeIndex}.{extension}";

                    // Extract video data using a stream to avoid loading the whole video into memory
                    using (System.IO.Stream videoStream = video.GetStream())
                    using (System.IO.FileStream fileStream = new System.IO.FileStream(outputPath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
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

        // Save the (potentially unchanged) presentation
        presentation.Save("Video_Processed.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}