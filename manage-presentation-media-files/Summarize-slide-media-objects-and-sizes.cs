// -----------------------------------------------------------------------------
// Example: Summarize slide media objects and sizes using C#
//
// Description:
// Demonstrates how to enumerate audio and video objects on each slide of a
// PowerPoint presentation, collect their file sizes, and output the result as
// a JSON report. The example also shows how to save the original presentation
// after processing using Aspose.Slides for .NET. This pattern can be used to
// audit media usage, enforce size limits, or generate documentation for PPTX
// files in a standalone console application.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Summarize, Slide, Media,
// Objects, Presentation Processing, JSON, Audio, Video, Automation
//
// Use Cases:
// - Generate a media usage report for PowerPoint presentations.
// - Validate that slide media does not exceed size constraints.
// - Automate extraction of media metadata for content management systems.
// - Integrate media auditing into .NET build or CI pipelines.
// -----------------------------------------------------------------------------
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
