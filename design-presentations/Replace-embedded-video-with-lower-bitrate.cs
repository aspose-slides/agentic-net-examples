using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceEmbeddedVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output presentation paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Folder containing lower‑bitrate video replacements
            string lowBitrateFolder = "LowBitrateVideos";

            // Verify that the input presentation exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation not found: " + inputPath);
                return;
            }

            // Verify that the low‑bitrate folder exists
            if (!Directory.Exists(lowBitrateFolder))
            {
                Console.WriteLine("Low‑bitrate video folder not found: " + lowBitrateFolder);
                return;
            }

            // Load the presentation
            Presentation pres = null;
            try
            {
                pres = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation. Exception: " + ex.Message);
                return;
            }

            try
            {
                // Iterate through all slides and replace embedded videos
                foreach (ISlide slide in pres.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is IVideoFrame)
                        {
                            IVideoFrame videoFrame = (IVideoFrame)shape;

                            // Determine a replacement video file name (example: original name with "_low" suffix)
                            // Since the original file name is not directly available, this example uses a fixed placeholder name.
                            string replacementFileName = "sample_low.mp4";
                            string replacementPath = Path.Combine(lowBitrateFolder, replacementFileName);

                            if (!File.Exists(replacementPath))
                            {
                                // If the specific replacement does not exist, skip this video
                                Console.WriteLine("Replacement video not found for: " + replacementFileName);
                                continue;
                            }

                            // Add the lower‑bitrate video to the presentation
                            FileStream videoStream = null;
                            try
                            {
                                videoStream = new FileStream(replacementPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                                IVideo newVideo = pres.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
                                // Assign the new video to the video frame
                                videoFrame.EmbeddedVideo = newVideo;
                            }
                            catch (NotSupportedException)
                            {
                                // Handle unsupported video format
                                Console.WriteLine("Video format not supported for file: " + replacementPath);
                            }
                            finally
                            {
                                if (videoStream != null)
                                    videoStream.Close();
                            }
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during processing: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is disposed
                if (pres != null)
                    pres.Dispose();
            }
        }
    }
}