// -----------------------------------------------------------------------------
// Example: Extract embedded media (videos and audios) from a PowerPoint file using C#
//
// Description:
// Demonstrates how to load a presentation with Aspose.Slides for .NET, iterate
// through embedded video and audio objects, retrieve their binary streams (BLOBs),
// and save them to disk. The example also shows how to access the static
// Media hyperlink object. This pattern can be used in console applications to
// automate media extraction from PPTX files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Media, Video, Audio,
// Hyperlink, BLOB, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of embedded video and audio files from presentations.
// - Build tools for analyzing or repurposing media assets in PPTX files.
// - Integrate media extraction into .NET workflows or migration pipelines.
// - Validate and archive presentation content before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkMediaExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            var inputPath = args.Length > 0 ? args[0] : "input.pptx";
            // Output directory for extracted media
            var outputDir = "ExtractedMedia";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Configure load options for BLOB management (keep source file locked)
            var loadOptions = new LoadOptions();
            loadOptions.BlobManagementOptions.PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked;

            try
            {
                // Load presentation with BLOB options
                using (var pres = new Presentation(inputPath, loadOptions))
                {
                    // Buffer for streaming data
                    var buffer = new byte[8 * 1024];

                    // Extract embedded videos
                    for (var i = 0; i < pres.Videos.Count; i++)
                    {
                        var video = pres.Videos[i];
                        var contentType = video.ContentType;
                        var slashPos = contentType.LastIndexOf('/');
                        var extension = contentType.Substring(slashPos + 1);
                        var outPath = Path.Combine(outputDir, $"video_{i}.{extension}");

                        using (var videoStream = video.GetStream())
                        using (var fileStream = new FileStream(outPath, FileMode.Create, FileAccess.Write, FileShare.Read))
                        {
                            int bytesRead;
                            while ((bytesRead = videoStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                fileStream.Write(buffer, 0, bytesRead);
                            }
                        }
                    }

                    // Extract embedded audios
                    for (var i = 0; i < pres.Audios.Count; i++)
                    {
                        var audio = pres.Audios[i];
                        var contentType = audio.ContentType;
                        var slashPos = contentType.LastIndexOf('/');
                        var extension = contentType.Substring(slashPos + 1);
                        var outPath = Path.Combine(outputDir, $"audio_{i}.{extension}");

                        using (var audioStream = audio.GetStream())
                        using (var fileStream = new FileStream(outPath, FileMode.Create, FileAccess.Write, FileShare.Read))
                        {
                            int bytesRead;
                            while ((bytesRead = audioStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                fileStream.Write(buffer, 0, bytesRead);
                            }
                        }
                    }

                    // Example of accessing the static Media hyperlink (no direct media data, just demonstration)
                    var mediaHyperlink = Hyperlink.Media;
                    Console.WriteLine($"Media Hyperlink Tooltip: {mediaHyperlink.Tooltip}");

                    // Save presentation before exit (optional - here we save a copy)
                    var savedPath = Path.Combine(outputDir, "presentation_copy.pptx");
                    pres.Save(savedPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine($"Error processing presentation: {ex.Message}");
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}
