using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Load the audio file and add an audio frame to the slide
        FileStream audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
        Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
        audioStream.Dispose();

        // Load the image that will be used as the audio frame thumbnail
        FileStream imageStream = new FileStream("eagle.jpeg", FileMode.Open, FileAccess.Read);
        Aspose.Slides.IPPImage thumbnailImage = presentation.Images.AddImage(imageStream);
        imageStream.Dispose();

        // Set the custom thumbnail image for the audio frame
        audioFrame.PictureFormat.Picture.Image = thumbnailImage;

        // Save the modified presentation
        presentation.Save("AudioFrameWithCustomThumbnail.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}