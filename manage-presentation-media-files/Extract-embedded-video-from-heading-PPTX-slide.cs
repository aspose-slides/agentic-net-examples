using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                byte[] buffer = new byte[8 * 1024];
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        if (shape is Aspose.Slides.IVideoFrame)
                        {
                            Aspose.Slides.IVideoFrame videoFrame = (Aspose.Slides.IVideoFrame)shape;
                            Aspose.Slides.IVideo video = videoFrame.EmbeddedVideo;
                            if (video != null)
                            {
                                string contentType = video.ContentType;
                                int slashPos = contentType.LastIndexOf('/');
                                string extension = (slashPos >= 0) ? contentType.Substring(slashPos + 1) : "bin";
                                string outputFile = $"slide{slideIndex}_shape{shapeIndex}_video.{extension}";
                                using (Stream videoStream = video.GetStream())
                                {
                                    using (FileStream fileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.Read))
                                    {
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
                }
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}