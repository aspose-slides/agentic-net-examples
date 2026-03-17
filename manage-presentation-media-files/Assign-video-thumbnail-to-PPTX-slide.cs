using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AssignVideoThumbnail
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to source video and custom thumbnail image
            string videoPath = "sample.mp4";
            string thumbnailPath = "thumb.png";
            string outputPath = "VideoWithCustomThumbnail.pptx";

            Aspose.Slides.Presentation pres = null;
            try
            {
                // Create a new presentation
                pres = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add the video to the presentation (from file bytes)
                byte[] videoBytes = File.ReadAllBytes(videoPath);
                Aspose.Slides.IVideo video = pres.Videos.AddVideo(videoBytes);

                // Add a video frame to the slide using the IVideo overload
                Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(10f, 10f, 400f, 300f, video);
                videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;

                // Load the custom thumbnail image (PPTX‑formatted image) into the presentation
                byte[] imageBytes = File.ReadAllBytes(thumbnailPath);
                Aspose.Slides.IPPImage thumbnailImage = pres.Images.AddImage(imageBytes);

                // Assign the custom image as the preview picture for the video frame
                videoFrame.PictureFormat.Picture.Image = thumbnailImage;

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is disposed to release resources
                if (pres != null)
                {
                    pres.Dispose();
                }
            }
        }
    }
}