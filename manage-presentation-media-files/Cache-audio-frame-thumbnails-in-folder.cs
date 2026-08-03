// -----------------------------------------------------------------------------
// Example: Cache audio frame thumbnails in folder using C#
//
// Description:
// Demonstrates how to extract audio frame thumbnails from a PowerPoint
// presentation and cache them as PNG files in a specified folder using
// Aspose.Slides for .NET. The example loads a presentation, iterates through
// each slide and audio frame, generates thumbnail images, saves them to the
// cache directory, and finally saves the (unchanged) presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Cache, Audio, Frame,
// Thumbnails, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction and caching of audio frame thumbnails from PPTX files.
// - Build C# utilities for PowerPoint media asset management.
// - Generate visual previews of embedded audio for documentation or UI.
// - Validate and process presentation media before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CacheAudioFrameThumbnails
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string presentationPath = "input.pptx";
            // Cache folder for thumbnails
            string cacheFolder = "Cache";

            // Verify input file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            // Ensure cache directory exists
            Directory.CreateDirectory(cacheFolder);

            try
            {
                // Load presentation
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    // Iterate through slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];
                        int audioIndex = 0;

                        // Iterate through shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];
                            // Check if the shape is an audio frame
                            AudioFrame audioFrame = shape as AudioFrame;
                            if (audioFrame != null)
                            {
                                // Generate thumbnail for the audio frame
                                IImage thumbnail = audioFrame.GetImage();
                                // Build thumbnail file name
                                string thumbnailPath = Path.Combine(
                                    cacheFolder,
                                    $"slide_{slideIndex + 1}_audio_{audioIndex + 1}.png");

                                // Save thumbnail image
                                thumbnail.Save(thumbnailPath, Aspose.Slides.ImageFormat.Png);
                                audioIndex++;
                            }
                        }
                    }

                    // Save the presentation before exiting
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
