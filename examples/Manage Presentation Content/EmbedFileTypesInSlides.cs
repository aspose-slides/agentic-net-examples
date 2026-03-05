using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Embed a video file
        FileStream videoStream = new FileStream("sample.mp4", FileMode.Open, FileAccess.Read);
        Aspose.Slides.IVideo video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
        Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 200, video);
        videoFrame.PlayMode = VideoPlayModePreset.Auto;
        videoStream.Close();

        // Embed an image file
        FileStream imageStream = new FileStream("image.png", FileMode.Open, FileAccess.Read);
        Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream, LoadingStreamBehavior.KeepLocked);
        slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 400, 150, 200, 150, image);
        imageStream.Close();

        // Save the presentation
        presentation.Save("EmbeddedFiles_out.pptx", SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}