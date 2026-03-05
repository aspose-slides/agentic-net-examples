using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesAudioThumbnail
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Load audio file stream
            System.IO.FileStream audioStream = new System.IO.FileStream("sample2.mp3", System.IO.FileMode.Open, System.IO.FileAccess.Read);

            // Add an audio frame to the slide
            Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(150f, 100f, 50f, 50f, audioStream);

            // Close the audio stream
            audioStream.Dispose();

            // Load an image from file
            Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile("eagle.jpeg");

            // Add the image to the presentation resources and get a PPImage
            Aspose.Slides.IPPImage ppImage = pres.Images.AddImage(img);

            // Set the image as the thumbnail for the audio frame
            audioFrame.PictureFormat.Picture.Image = ppImage;

            // Save the presentation
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            pres.Dispose();
        }
    }
}