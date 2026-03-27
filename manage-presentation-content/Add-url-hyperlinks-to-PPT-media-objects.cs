using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddMediaHyperlinks
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output presentation paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Create or load presentation
            Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Presentation(inputPath);
            }
            else
            {
                presentation = new Presentation();
            }

            // Get first slide
            ISlide slide = presentation.Slides[0];

            // ---------- Add Video Frame with Hyperlink ----------
            string videoFile = "sampleVideo.mp4";
            if (File.Exists(videoFile))
            {
                // Add video frame from external file
                IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 150, videoFile);
                // Set hyperlink on click
                videoFrame.HyperlinkClick = new Hyperlink("https://www.example.com/video");
                videoFrame.HyperlinkClick.Tooltip = "Open video link";
            }

            // ---------- Add Audio Frame with Hyperlink ----------
            string audioFile = "sampleAudio.mp3";
            if (File.Exists(audioFile))
            {
                // Add linked audio frame
                IAudioFrame audioFrame = slide.Shapes.AddAudioFrameLinked(10, 10, 100, 100, audioFile);
                // Set hyperlink on click
                audioFrame.HyperlinkClick = new Hyperlink("https://www.example.com/audio");
                audioFrame.HyperlinkClick.Tooltip = "Open audio link";
            }

            // ---------- Add Image with Hyperlink ----------
            string imageFile = "sampleImage.png";
            if (File.Exists(imageFile))
            {
                // Add image to presentation's image collection
                IPPImage image = presentation.Images.AddImage(File.ReadAllBytes(imageFile));
                // Create picture frame on slide
                IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 300, 100, 100, image);
                // Set hyperlink on click
                pictureFrame.HyperlinkClick = new Hyperlink("https://www.example.com/image");
                pictureFrame.HyperlinkClick.Tooltip = "Open image link";
            }

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Dispose presentation resources
            presentation.Dispose();
        }
    }
}