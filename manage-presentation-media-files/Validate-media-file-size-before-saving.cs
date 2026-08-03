// -----------------------------------------------------------------------------
// Example: Validate media file size before saving using C#
//
// Description:
// Demonstrates how to validate audio and video media file sizes before saving a
// PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// loads a PPTX file, checks each embedded audio and video against a maximum
// size limit, and saves the presentation only if all media files meet the
// criteria.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Media, Audio, Video,
// File, Size, Presentation Processing, Office Automation
//
// Use Cases:
// - Ensure embedded media files do not exceed size constraints before publishing.
// - Build automated validation tools for PowerPoint presentations in .NET.
// - Prevent oversized media from causing performance or storage issues.
// - Integrate media size checks into CI/CD pipelines for presentation assets.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MediaSizeValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Define maximum allowed media file size (e.g., 5 MB)
            const long maxMediaSizeBytes = 5L * 1024L * 1024L;

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Validate audio files
                    for (int i = 0; i < pres.Audios.Count; i++)
                    {
                        var audio = pres.Audios[i];
                        if (audio.BinaryData != null && audio.BinaryData.Length > maxMediaSizeBytes)
                        {
                            Console.WriteLine($"Audio file at index {i} exceeds size limit.");
                            return;
                        }
                    }

                    // Validate video files
                    for (int i = 0; i < pres.Videos.Count; i++)
                    {
                        var video = pres.Videos[i];
                        // Prefer streaming to avoid loading whole video into memory
                        using (Stream videoStream = video.GetStream())
                        {
                            if (videoStream.Length > maxMediaSizeBytes)
                            {
                                Console.WriteLine($"Video file at index {i} exceeds size limit.");
                                return;
                            }
                        }
                    }

                    // Save the presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
