using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddVideoCaptionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define file names (adjust as needed)
                string mediaFileName = "sample_video.mp4";
                string trackFileName = "sample_caption.vtt";
                string outAddFileName = "VideoWithCaption_added.pptx";
                string outCaptionFileName = "extracted_caption.vtt";
                string outRemoveFileName = "VideoWithCaption_removed.pptx";

                // Build full paths based on current directory
                string mediaFile = Path.Combine(Environment.CurrentDirectory, mediaFileName);
                string trackFile = Path.Combine(Environment.CurrentDirectory, trackFileName);
                string outAddPath = Path.Combine(Environment.CurrentDirectory, outAddFileName);
                string outCaption = Path.Combine(Environment.CurrentDirectory, outCaptionFileName);
                string outRemovePath = Path.Combine(Environment.CurrentDirectory, outRemoveFileName);

                // Create a new presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
                {
                    // Add video to the presentation
                    Aspose.Slides.IVideo video = pres.Videos.AddVideo(File.ReadAllBytes(mediaFile));

                    // Add video frame to the first slide
                    Aspose.Slides.IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

                    // Add caption track to the video frame
                    string trackName = "EnglishCaption";
                    videoFrame.CaptionTracks.Add(trackName, trackFile);

                    // Save presentation with caption added
                    pres.Save(outAddPath, Aspose.Slides.Export.SaveFormat.Pptx);

                    // Retrieve the video frame (assumes it's the first shape)
                    Aspose.Slides.IVideoFrame retrievedVideoFrame = pres.Slides[0].Shapes[0] as Aspose.Slides.IVideoFrame;
                    if (retrievedVideoFrame != null)
                    {
                        // Extract each caption track to a file
                        foreach (var captionTrack in retrievedVideoFrame.CaptionTracks)
                        {
                            File.WriteAllBytes(outCaption, captionTrack.BinaryData);
                        }

                        // Remove all caption tracks
                        retrievedVideoFrame.CaptionTracks.Clear();

                        // Save presentation after removing captions
                        pres.Save(outRemovePath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}