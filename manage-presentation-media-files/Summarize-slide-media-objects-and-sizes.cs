using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MediaSummaryApp
{
    class Program
    {
        // Helper class to store media information
        private class MediaInfo
        {
            public string MediaType { get; set; }
            public long FileSize { get; set; }
        }

        // Helper class to store slide media collection
        private class SlideMediaInfo
        {
            public int SlideIndex { get; set; }
            public List<MediaInfo> MediaItems { get; set; } = new List<MediaInfo>();
        }

        static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string jsonOutputPath = args.Length > 1 ? args[1] : "media_summary.json";
            string presentationOutputPath = Path.Combine(Path.GetDirectoryName(inputPath) ?? "", "output.pptx");

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    List<SlideMediaInfo> summary = new List<SlideMediaInfo>();

                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        ISlide slide = pres.Slides[i];
                        SlideMediaInfo slideInfo = new SlideMediaInfo { SlideIndex = i + 1 };

                        foreach (IShape shape in slide.Shapes)
                        {
                            // Audio frames
                            IAudioFrame audioFrame = shape as IAudioFrame;
                            if (audioFrame != null && audioFrame.EmbeddedAudio != null)
                            {
                                long size = audioFrame.EmbeddedAudio.BinaryData.Length;
                                slideInfo.MediaItems.Add(new MediaInfo { MediaType = "Audio", FileSize = size });
                            }

                            // Video frames
                            IVideoFrame videoFrame = shape as IVideoFrame;
                            if (videoFrame != null && videoFrame.EmbeddedVideo != null)
                            {
                                long size = videoFrame.EmbeddedVideo.BinaryData.Length;
                                slideInfo.MediaItems.Add(new MediaInfo { MediaType = "Video", FileSize = size });
                            }
                        }

                        if (slideInfo.MediaItems.Count > 0)
                        {
                            summary.Add(slideInfo);
                        }
                    }

                    // Serialize summary to JSON
                    string json = JsonSerializer.Serialize(summary, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(jsonOutputPath, json);
                    Console.WriteLine("Media summary written to: " + jsonOutputPath);

                    // Save presentation before exit
                    pres.Save(presentationOutputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}