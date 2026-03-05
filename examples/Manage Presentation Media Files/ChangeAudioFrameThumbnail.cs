using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Input audio and image files
        string audioPath = "sample2.mp3";
        string imagePath = "eagle.jpeg";
        // Output presentation file
        string outputPath = "AudioFrameThumbnail_out.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add an audio frame to the slide
        FileStream audioStream = new FileStream(audioPath, FileMode.Open, FileAccess.Read);
        Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(150f, 100f, 50f, 50f, audioStream);
        audioStream.Dispose();

        // Add an image to the presentation resources
        FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
        Aspose.Slides.IPPImage audioImage = pres.Images.AddImage(imageStream);
        imageStream.Dispose();

        // Set the image as the audio frame's thumbnail/preview
        audioFrame.PictureFormat.Picture.Image = audioImage;

        // Save the presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}