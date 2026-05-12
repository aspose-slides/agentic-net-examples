using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceEmbeddedVideos
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                var presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate over each embedded video
                for (var i = 0; i < presentation.Videos.Count; i++)
                {
                    var oldVideo = presentation.Videos[i];

                    // Read original video data into a byte array
                    byte[] originalData;
                    using (var videoStream = oldVideo.GetStream())
                    using (var memory = new MemoryStream())
                    {
                        videoStream.CopyTo(memory);
                        originalData = memory.ToArray();
                    }

                    // TODO: Replace this placeholder with actual lower‑bitrate conversion logic
                    var lowerBitrateData = originalData; // Placeholder for compressed video bytes

                    // Add the lower‑bitrate video to the presentation
                    var newVideo = presentation.Videos.AddVideo(lowerBitrateData);

                    // Update all video frames that reference the old video
                    foreach (var slide in presentation.Slides)
                    {
                        foreach (var shape in slide.Shapes)
                        {
                            if (shape is Aspose.Slides.IVideoFrame videoFrame)
                            {
                                if (videoFrame.EmbeddedVideo == oldVideo)
                                {
                                    videoFrame.EmbeddedVideo = newVideo;
                                }
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}